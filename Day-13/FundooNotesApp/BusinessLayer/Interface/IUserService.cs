using ModelLayer;

namespace BusinessLayer.Interface;

public interface IUserService
{
    Task<List<UserResponseDto>> GetAllUsersAsync();
    Task<UserResponseDto?> GetUserByIdAsync(int id);
    Task<UserResponseDto?> UpdateUserAsync(int id, UpdateUserDto dto);
    Task<UserResponseDto?> PatchEmailAsync(int id, PatchEmailDto dto);
    Task<bool> DeleteUserAsync(int id);
}
