using BusinessLayer.Interface;
using ModelLayer;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserResponseDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Select(MapToResponseDto).ToList();
    }

    public async Task<UserResponseDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user != null ? MapToResponseDto(user) : null;
    }

    public async Task<UserResponseDto?> UpdateUserAsync(int id, UpdateUserDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return null;

        var cleanEmail = dto.Email.Trim();
        if (!string.Equals(user.Email, cleanEmail, StringComparison.OrdinalIgnoreCase))
        {
            if (await _userRepository.UserExistsAsync(cleanEmail))
            {
                throw new InvalidOperationException($"User with email '{cleanEmail}' already exists.");
            }
            user.Email = cleanEmail;
        }

        user.FirstName = dto.FirstName.Trim();
        user.LastName = dto.LastName.Trim();

        if (!string.IsNullOrWhiteSpace(dto.Role) && (dto.Role == "User" || dto.Role == "Admin"))
        {
            user.Role = dto.Role;
        }

        var updated = await _userRepository.UpdateUserAsync(user);
        return MapToResponseDto(updated);
    }

    public async Task<UserResponseDto?> PatchEmailAsync(int id, PatchEmailDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return null;

        var cleanEmail = dto.Email.Trim();
        if (string.Equals(user.Email, cleanEmail, StringComparison.OrdinalIgnoreCase))
        {
            return MapToResponseDto(user);
        }

        if (await _userRepository.UserExistsAsync(cleanEmail))
        {
            throw new InvalidOperationException($"User with email '{cleanEmail}' already exists.");
        }

        user.Email = cleanEmail;
        var updated = await _userRepository.UpdateUserAsync(user);
        return MapToResponseDto(updated);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }

    private static UserResponseDto MapToResponseDto(User user)
    {
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
