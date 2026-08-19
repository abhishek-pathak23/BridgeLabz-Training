using ModelLayer;

namespace BusinessLayer.Interface;

/// <summary>
/// Day-14: Auth service contract — returns JWT tokens with UserId + Email claims.
/// </summary>
public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(UserRegisterDto dto);
    Task<AuthResponseDto> LoginAsync(UserLoginDto dto);
    Task<string> ForgotPasswordAsync(ForgotPasswordDto dto);
    Task<bool> ResetPasswordAsync(ResetPasswordDto dto);
    Task<UserResponseDto?> GetProfileAsync(int userId);
}
