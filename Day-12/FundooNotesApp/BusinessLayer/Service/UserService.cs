using System.Security.Cryptography;
using BusinessLayer.Interface;
using ModelLayer;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserResponseDto> RegisterAsync(UserRegisterDto dto)
    {
        if (await _userRepository.UserExistsAsync(dto.Email))
        {
            throw new InvalidOperationException($"User with email '{dto.Email}' already exists.");
        }

        _passwordHasher.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var user = new User
        {
            FirstName = dto.FirstName.Trim(),
            LastName = dto.LastName.Trim(),
            Email = dto.Email.Trim().ToLower(),
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            CreatedAt = DateTime.UtcNow
        };

        var created = await _userRepository.CreateUserAsync(user);
        return MapToUserResponseDto(created);
    }

    public async Task<UserResponseDto> LoginAsync(UserLoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var isPasswordValid = _passwordHasher.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt);
        if (!isPasswordValid)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        return MapToUserResponseDto(user);
    }

    public async Task<string> ForgotPasswordAsync(ForgotPasswordDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new KeyNotFoundException($"No account registered with email '{dto.Email}'.");
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
            throw new KeyNotFoundException($"No account registered with email '{dto.Email}'.");
        }

        if (string.IsNullOrWhiteSpace(user.ResetToken) || user.ResetToken != dto.Token)
        {
            throw new ArgumentException("Invalid or expired password reset token.");
        }

        if (user.ResetTokenExpiry == null || user.ResetTokenExpiry < DateTime.UtcNow)
        {
            throw new ArgumentException("Password reset token has expired.");
        }

        _passwordHasher.CreatePasswordHash(dto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.ResetToken = null;
        user.ResetTokenExpiry = null;

        await _userRepository.UpdateUserAsync(user);
        return true;
    }

    public async Task<List<UserResponseDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Select(MapToUserResponseDto).ToList();
    }

    public async Task<UserResponseDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user != null ? MapToUserResponseDto(user) : null;
    }

    public async Task<UserResponseDto?> UpdateUserAsync(int id, UpdateUserDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return null;

        user.FirstName = dto.FirstName.Trim();
        user.LastName = dto.LastName.Trim();
        user.Email = dto.Email.Trim().ToLower();

        await _userRepository.UpdateUserAsync(user);
        return MapToUserResponseDto(user);
    }

    public async Task<UserResponseDto?> PatchEmailAsync(int id, PatchEmailDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return null;

        user.Email = dto.Email.Trim().ToLower();

        await _userRepository.UpdateUserAsync(user);
        return MapToUserResponseDto(user);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }

    private static UserResponseDto MapToUserResponseDto(User user)
    {
        return new UserResponseDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }
}
