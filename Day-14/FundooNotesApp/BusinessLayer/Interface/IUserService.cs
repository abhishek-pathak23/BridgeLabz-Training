namespace BusinessLayer.Interface;

using ModelLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
    Task<UserResponseDto?> GetUserByIdAsync(int id);
    Task<UserResponseDto?> UpdateUserAsync(int id, UpdateProfileDto dto);
    Task<bool> DeleteUserAsync(int id);
}
