namespace BusinessLayer.Service;

using BusinessLayer.Interface;
using ModelLayer;
using RepositoryLayer.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Select(ToResponseDto);
    }

    public async Task<UserResponseDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user == null ? null : ToResponseDto(user);
    }

    public async Task<UserResponseDto?> UpdateUserAsync(int id, UpdateProfileDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;

        await _userRepository.UpdateUserAsync(user);
        return ToResponseDto(user);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }

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
