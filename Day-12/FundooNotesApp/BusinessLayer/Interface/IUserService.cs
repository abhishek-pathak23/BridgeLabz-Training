using ModelLayer;

namespace BusinessLayer.Interface;

public interface IUserService
{
    Task<UserResponseDto> RegisterAsync(UserRegisterDto dto);
    Task<UserResponseDto> LoginAsync(UserLoginDto dto);
    Task<string> ForgotPasswordAsync(ForgotPasswordDto dto);
    Task<bool> ResetPasswordAsync(ResetPasswordDto dto);
    Task<List<UserResponseDto>> GetAllUsersAsync();
    Task<UserResponseDto?> GetUserByIdAsync(int id);
    Task<UserResponseDto?> UpdateUserAsync(int id, UpdateUserDto dto);
    Task<UserResponseDto?> PatchEmailAsync(int id, PatchEmailDto dto);
    Task<bool> DeleteUserAsync(int id);
}
