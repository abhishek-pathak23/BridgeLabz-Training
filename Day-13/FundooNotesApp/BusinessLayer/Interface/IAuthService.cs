using ModelLayer;

namespace BusinessLayer.Interface;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(UserRegisterDto dto);
    Task<AuthResponseDto> LoginAsync(UserLoginDto dto);
    Task<User?> ValidateGroundworkTokenAsync(string token);
    string GenerateGroundworkToken(User user);
    Task<string> ForgotPasswordAsync(ForgotPasswordDto dto);
    Task<bool> ResetPasswordAsync(ResetPasswordDto dto);
    Task<UserResponseDto?> GetProfileAsync(int userId);
}
