using System.Security.Cryptography;
using System.Text;
using BusinessLayer.Interface;
using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly string _tokenSecret;

    public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenSecret = configuration["AuthGroundwork:SecretKey"] ?? "FundooNotesApp_Day13_Groundwork_Secret_Key_For_Auth_Tokens_2026";
    }

    public async Task<AuthResponseDto> RegisterAsync(UserRegisterDto dto)
    {
        if (await _userRepository.UserExistsAsync(dto.Email))
        {
            throw new InvalidOperationException($"User with email '{dto.Email}' already exists.");
        }

        _passwordHasher.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var assignedRole = string.IsNullOrWhiteSpace(dto.Role) ? "User" : dto.Role.Trim();
        if (assignedRole != "User" && assignedRole != "Admin")
        {
            assignedRole = "User";
        }

        var user = new User
        {
            FirstName = dto.FirstName.Trim(),
            LastName = dto.LastName.Trim(),
            Email = dto.Email.Trim(),
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Role = assignedRole,
            CreatedAt = DateTime.UtcNow
        };

        var createdUser = await _userRepository.CreateUserAsync(user);
        var token = GenerateGroundworkToken(createdUser);

        var userDto = new UserResponseDto
        {
            Id = createdUser.Id,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName,
            Email = createdUser.Email,
            Role = createdUser.Role,
            CreatedAt = createdUser.CreatedAt
        };

        return new AuthResponseDto
        {
            Success = true,
            Message = "User registered successfully with assigned role.",
            AuthScheme = "GroundworkBearer",
            GroundworkToken = token,
            User = userDto
        };
    }

    public async Task<AuthResponseDto> LoginAsync(UserLoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        if (!_passwordHasher.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var token = GenerateGroundworkToken(user);

        var userDto = new UserResponseDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt
        };

        return new AuthResponseDto
        {
            Success = true,
            Message = "Authentication successful.",
            AuthScheme = "GroundworkBearer",
            GroundworkToken = token,
            User = userDto
        };
    }

    public string GenerateGroundworkToken(User user)
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var rawPayload = $"{user.Id}:{user.Email}:{user.Role}:{timestamp}";

        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_tokenSecret));
        var signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawPayload));
        var signature = Convert.ToBase64String(signatureBytes);

        var fullTokenPayload = $"{rawPayload}:{signature}";
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(fullTokenPayload));
    }

    public async Task<User?> ValidateGroundworkTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            return null;

        try
        {
            var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var parts = decoded.Split(':', 5);
            if (parts.Length < 5)
                return null;

            var idStr = parts[0];
            var email = parts[1];
            var role = parts[2];
            var timestampStr = parts[3];
            var signature = parts[4];

            var rawPayload = $"{idStr}:{email}:{role}:{timestampStr}";

            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_tokenSecret));
            var expectedSignature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(rawPayload)));

            if (!CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(signature),
                Encoding.UTF8.GetBytes(expectedSignature)))
            {
                return null;
            }

            if (!int.TryParse(idStr, out var userId))
                return null;

            return await _userRepository.GetByIdAsync(userId);
        }
        catch
        {
            return null;
        }
    }

    public async Task<string> ForgotPasswordAsync(ForgotPasswordDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new KeyNotFoundException($"No user found with email '{dto.Email}'.");
        }

        var resetToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
        user.ResetToken = resetToken;
        user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(30);

        await _userRepository.UpdateUserAsync(user);
        return resetToken;
    }

    public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new KeyNotFoundException($"No user found with email '{dto.Email}'.");
        }

        if (string.IsNullOrEmpty(user.ResetToken) || user.ResetToken != dto.Token)
        {
            throw new ArgumentException("Invalid reset token provided.");
        }

        if (user.ResetTokenExpiry == null || user.ResetTokenExpiry < DateTime.UtcNow)
        {
            throw new ArgumentException("Reset token has expired. Please request a new one.");
        }

        _passwordHasher.CreatePasswordHash(dto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.ResetToken = null;
        user.ResetTokenExpiry = null;

        await _userRepository.UpdateUserAsync(user);
        return true;
    }

    public async Task<UserResponseDto?> GetProfileAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            return null;

        return new UserResponseDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt
        };
    }
}
