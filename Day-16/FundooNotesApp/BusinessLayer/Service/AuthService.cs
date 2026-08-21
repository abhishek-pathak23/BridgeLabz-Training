using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BusinessLayer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service;

/// <summary>
/// Day-14: AuthService — generates real JWT tokens with Claims.
/// JWT Payload includes:
///   • sub  = UserId   (to identify the user; not name because name can change / be shared)
///   • email = UserEmail
///   • role  = UserRole
///   • jti   = unique token id
/// Paste the returned token into https://jwt.io to inspect.
/// </summary>
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IConfiguration _configuration;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _configuration = configuration;
    }

    // ─── Register ────────────────────────────────────────────────────────────

    public async Task<AuthResponseDto> RegisterAsync(UserRegisterDto dto)
    {
        if (await _userRepository.UserExistsAsync(dto.Email))
            throw new InvalidOperationException($"User with email '{dto.Email}' already exists.");

        _passwordHasher.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

        var role = string.IsNullOrWhiteSpace(dto.Role) ? "User" : dto.Role.Trim();
        if (role != "User" && role != "Admin") role = "User";

        var user = new User
        {
            FirstName = dto.FirstName.Trim(),
            LastName  = dto.LastName.Trim(),
            Email     = dto.Email.Trim(),
            PasswordHash = hash,
            PasswordSalt = salt,
            Role = role,
            CreatedAt = DateTime.UtcNow
        };

        var created = await _userRepository.CreateUserAsync(user);
        var token   = GenerateJwtToken(created);

        return new AuthResponseDto
        {
            Success    = true,
            Message    = "User registered successfully. JWT token issued.",
            AuthScheme = "Bearer",
            Token      = token,
            User       = ToResponseDto(created)
        };
    }

    // ─── Login ────────────────────────────────────────────────────────────────

    public async Task<AuthResponseDto> LoginAsync(UserLoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email)
            ?? throw new UnauthorizedAccessException("Invalid email or password.");

        if (!_passwordHasher.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            throw new UnauthorizedAccessException("Invalid email or password.");

        var token = GenerateJwtToken(user);

        return new AuthResponseDto
        {
            Success    = true,
            Message    = "Login successful. JWT token issued.",
            AuthScheme = "Bearer",
            Token      = token,
            User       = ToResponseDto(user)
        };
    }

    // ─── JWT Token Generation (Day-14 Core) ──────────────────────────────────

    /// <summary>
    /// Generates a signed JWT token.
    /// Claims embedded:
    ///   • sub       = user.Id     → identifies the user (UserId — not name!)
    ///   • email     = user.Email  → secondary identifier
    ///   • role      = user.Role
    ///   • given_name/family_name  → human-readable name (only for display, NOT identity)
    ///   • jti       = unique token id (prevents replay)
    ///   • iat / exp = issued-at / expiry
    /// </summary>
    public string GenerateJwtToken(User user)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var secretKey   = jwtSettings["SecretKey"] ?? "FundooNotes_Day14_JWT_Secret_Key_Min32Chars!!";
        var issuer      = jwtSettings["Issuer"]    ?? "FundooNotesApp";
        var audience    = jwtSettings["Audience"]  ?? "FundooNotesUsers";
        var expMinutes  = int.TryParse(jwtSettings["ExpiryMinutes"], out var m) ? m : 60;

        var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // ─── JWT Claims — WHY sub (UserId) and email? ─────────────────────
        // • 'sub' = Subject = UserId (int). This is the canonical identity claim.
        //   We use UserId because:
        //     - Names can be shared or changed.
        //     - UserId is unique, immutable, and maps directly to the DB row.
        // • 'email' is added for human-readable identification (shown in UI, logs).
        //   Email can change (theoretically), so it's NOT the primary identity.
        // • Together, sub + email let us identify AND display who the user is.
        // ──────────────────────────────────────────────────────────────────

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub,        user.Id.ToString()),          // ← PRIMARY identity (UserId)
            new(JwtRegisteredClaimNames.Email,       user.Email),                  // ← secondary (human-readable)
            new(JwtRegisteredClaimNames.GivenName,   user.FirstName),              // ← display only
            new(JwtRegisteredClaimNames.FamilyName,  user.LastName),               // ← display only
            new(JwtRegisteredClaimNames.Jti,         Guid.NewGuid().ToString()),   // ← unique token id
            new(ClaimTypes.NameIdentifier,           user.Id.ToString()),          // ← ASP.NET compat
            new(ClaimTypes.Email,                    user.Email),                  // ← ASP.NET compat
            new(ClaimTypes.Role,                     user.Role),                   // ← ASP.NET [Authorize(Roles=...)]
            new("user_id",                           user.Id.ToString()),          // ← custom readable claim
        };

        var token = new JwtSecurityToken(
            issuer:             issuer,
            audience:           audience,
            claims:             claims,
            notBefore:          DateTime.UtcNow,
            expires:            DateTime.UtcNow.AddMinutes(expMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    // ─── Forgot / Reset Password ──────────────────────────────────────────────

    public async Task<string> ForgotPasswordAsync(ForgotPasswordDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email)
            ?? throw new KeyNotFoundException($"No user found with email '{dto.Email}'.");

        var resetToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
        user.ResetToken       = resetToken;
        user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(30);

        await _userRepository.UpdateUserAsync(user);
        return resetToken;
    }

    public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email)
            ?? throw new KeyNotFoundException($"No user found with email '{dto.Email}'.");

        if (string.IsNullOrEmpty(user.ResetToken) || user.ResetToken != dto.Token)
            throw new ArgumentException("Invalid reset token.");

        if (user.ResetTokenExpiry == null || user.ResetTokenExpiry < DateTime.UtcNow)
            throw new ArgumentException("Reset token has expired.");

        _passwordHasher.CreatePasswordHash(dto.NewPassword, out byte[] hash, out byte[] salt);
        user.PasswordHash     = hash;
        user.PasswordSalt     = salt;
        user.ResetToken       = null;
        user.ResetTokenExpiry = null;

        await _userRepository.UpdateUserAsync(user);
        return true;
    }

    // ─── Profile ──────────────────────────────────────────────────────────────

    public async Task<UserResponseDto?> GetProfileAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        return user == null ? null : ToResponseDto(user);
    }

    // ─── Helpers ──────────────────────────────────────────────────────────────

    private static UserResponseDto ToResponseDto(User u) => new()
    {
        Id        = u.Id,
        FirstName = u.FirstName,
        LastName  = u.LastName,
        Email     = u.Email,
        Role      = u.Role,
        CreatedAt = u.CreatedAt
    };
}
