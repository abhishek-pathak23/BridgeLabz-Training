using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace FundooNotesApp.Controllers;

/// <summary>
/// Day-14: AuthController — handles Registration, Login, Profile, and JWT Debugging.
///
/// JWT Claims Explanation:
///   • 'sub' (Subject) = UserId  — primary identity. We use UserId (not name) because:
///       - Names can be shared (e.g., two users named "Rahul")
///       - Names can change over time
///       - UserId is unique, immutable, and directly maps to the DB row
///   • 'email' = Email address — secondary, human-readable identifier
///   • Together, sub + email let us uniquely identify AND display the user.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ICurrentUserService _currentUserService;

    public AuthController(IAuthService authService, ICurrentUserService currentUserService)
    {
        _authService        = authService;
        _currentUserService = currentUserService;
    }

    // ── POST /api/auth/register ───────────────────────────────────────────────

    /// <summary>Register a new user. Returns a JWT token with sub=UserId + email claims.</summary>
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
    {
        try
        {
            var result = await _authService.RegisterAsync(dto);
            return CreatedAtAction(nameof(GetProfile), new { }, result);
        }
        catch (InvalidOperationException ex) { return Conflict(new { Message = ex.Message }); }
        catch (Exception ex)                 { return BadRequest(new { Message = ex.Message }); }
    }

    // ── POST /api/auth/login ──────────────────────────────────────────────────

    /// <summary>
    /// Login. Returns a JWT token.
    /// Copy the 'token' value → paste into Swagger Authorize (Bearer {token})
    /// or paste into https://jwt.io to inspect claims.
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
        catch (UnauthorizedAccessException ex) { return Unauthorized(new { Message = ex.Message }); }
        catch (Exception ex)                   { return BadRequest(new { Message = ex.Message }); }
    }

    // ── GET /api/auth/me ──────────────────────────────────────────────────────

    /// <summary>Get current user profile. UserId is read from JWT 'sub' claim.</summary>
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetProfile()
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "User is not authenticated." });

        var profile = await _authService.GetProfileAsync(userId.Value);
        if (profile == null)
            return NotFound(new { Message = "User profile not found." });

        return Ok(new
        {
            Message = "Profile retrieved from JWT sub (UserId) claim.",
            Profile = profile
        });
    }

    // ── GET /api/auth/jwt-debugger ────────────────────────────────────────────

    /// <summary>
    /// Decodes your JWT token and shows Header, Payload, and all claims.
    /// </summary>
    [HttpGet("jwt-debugger")]
    [Authorize]
    public IActionResult JwtDebugger()
    {
        // Extract raw token from Authorization header
        var rawToken = string.Empty;
        if (Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            rawToken = authHeader.ToString();
            if (rawToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                rawToken = rawToken[7..].Trim();
        }

        var debugInfo = _currentUserService.GetJwtDebugInfo(rawToken);

        return Ok(new
        {
            Message = "JWT Debugger — decoded claims from your Bearer token. Paste the token at https://jwt.io to verify.",
            Debug   = debugInfo
        });
    }

    // ── POST /api/auth/forgot-password ────────────────────────────────────────

    /// <summary>Generate a password reset token (valid 30 minutes).</summary>
    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        try
        {
            var token = await _authService.ForgotPasswordAsync(dto);
            return Ok(new { Message = "Reset token generated. Valid for 30 minutes.", ResetToken = token });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
        catch (Exception ex)            { return BadRequest(new { Message = ex.Message }); }
    }

    // ── POST /api/auth/reset-password ────────────────────────────────────────

    /// <summary>Reset password using the reset token.</summary>
    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
    {
        try
        {
            await _authService.ResetPasswordAsync(dto);
            return Ok(new { Message = "Password reset successfully. Please login with your new password." });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
        catch (ArgumentException ex)    { return BadRequest(new { Message = ex.Message }); }
        catch (Exception ex)            { return BadRequest(new { Message = ex.Message }); }
    }
}
