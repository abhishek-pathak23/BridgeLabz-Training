using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace FundooNotesApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ICurrentUserService _currentUserService;

    public AuthController(IAuthService authService, ICurrentUserService currentUserService)
    {
        _authService = authService;
        _currentUserService = currentUserService;
    }

    /// <summary>
    /// POST /api/auth/register - Register new user account with role assignment (Groundwork Auth)
    /// </summary>
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
    {
        try
        {
            var result = await _authService.RegisterAsync(dto);
            return CreatedAtAction(nameof(GetProfile), new { }, result);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    /// <summary>
    /// POST /api/auth/login - Authenticate credentials and receive Groundwork Token
    /// </summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
    {
        try
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    /// <summary>
    /// GET /api/auth/me - Retrieve current authenticated user profile
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetProfile()
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
        {
            return Unauthorized(new { Message = "User is not authenticated." });
        }

        var profile = await _authService.GetProfileAsync(userId.Value);
        if (profile == null)
        {
            return NotFound(new { Message = "User profile not found." });
        }

        return Ok(new
        {
            Message = "Profile retrieved successfully from authenticated context.",
            Profile = profile
        });
    }

    /// <summary>
    /// GET /api/auth/claims - Inspect resolved claims and authentication identity (Groundwork Diagnostics)
    /// </summary>
    [HttpGet("claims")]
    [Authorize]
    public IActionResult GetClaims()
    {
        var claimsInfo = _currentUserService.GetClaimsDebugInfo();
        return Ok(new
        {
            Message = "Claims and identity information resolved from Groundwork authentication token.",
            Data = claimsInfo
        });
    }

    /// <summary>
    /// GET /api/auth/admin-only - Protected endpoint requiring Admin role
    /// </summary>
    [HttpGet("admin-only")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminOnlyEndpoint()
    {
        return Ok(new
        {
            Message = "Access Granted. You have valid Admin role permissions.",
            User = _currentUserService.Email,
            Role = _currentUserService.Role
        });
    }

    /// <summary>
    /// GET /api/auth/user-only - Protected endpoint accessible to standard Users and Admins
    /// </summary>
    [HttpGet("user-only")]
    [Authorize(Roles = "User,Admin")]
    public IActionResult UserOnlyEndpoint()
    {
        return Ok(new
        {
            Message = "Access Granted. Authorized user endpoint accessible to registered accounts.",
            User = _currentUserService.Email,
            Role = _currentUserService.Role
        });
    }

    /// <summary>
    /// POST /api/auth/forgot-password - Generate password reset token
    /// </summary>
    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        try
        {
            var resetToken = await _authService.ForgotPasswordAsync(dto);
            return Ok(new
            {
                Message = "Password reset token generated successfully. Valid for 30 minutes.",
                ResetToken = resetToken
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    /// <summary>
    /// POST /api/auth/reset-password - Reset password using reset token
    /// </summary>
    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
    {
        try
        {
            await _authService.ResetPasswordAsync(dto);
            return Ok(new { Message = "Password has been reset successfully. Please login with your new password." });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}
