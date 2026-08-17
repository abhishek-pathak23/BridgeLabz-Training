using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace FundooNotesApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IExternalQuoteService _quoteService;

    public UserController(IUserService userService, IExternalQuoteService quoteService)
    {
        _userService = userService;
        _quoteService = quoteService;
    }

    /// <summary>
    /// GET /api/User - Get all users (REST Verb: GET)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    /// <summary>
    /// GET /api/User/{id} - Get user by ID (REST Verb: GET)
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound(new { Message = $"User with ID {id} was not found." });
        }
        return Ok(user);
    }

    /// <summary>
    /// POST /api/User/register - Register new user with password encryption (REST Verb: POST)
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
    {
        try
        {
            var created = await _userService.RegisterAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new
            {
                Message = "User registered successfully.",
                User = created
            });
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
    /// POST /api/User/login - Authenticate user credentials (REST Verb: POST)
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
    {
        try
        {
            var user = await _userService.LoginAsync(dto);
            return Ok(new
            {
                Message = "Login successful.",
                User = user
            });
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
    /// POST /api/User/forgot-password - Generate password recovery token (REST Verb: POST)
    /// </summary>
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        try
        {
            var resetToken = await _userService.ForgotPasswordAsync(dto);
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
    /// POST /api/User/reset-password - Reset password using recovery token (REST Verb: POST)
    /// </summary>
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
    {
        try
        {
            await _userService.ResetPasswordAsync(dto);
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

    /// <summary>
    /// PUT /api/User/{id} - Full update of user profile (REST Verb: PUT)
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
    {
        try
        {
            var updated = await _userService.UpdateUserAsync(id, dto);
            if (updated == null)
            {
                return NotFound(new { Message = $"User with ID {id} was not found." });
            }
            return Ok(new { Message = "User profile updated successfully.", User = updated });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    /// <summary>
    /// PATCH /api/User/{id}/email - Partial update of user email (REST Verb: PATCH)
    /// </summary>
    [HttpPatch("{id:int}/email")]
    public async Task<IActionResult> PatchEmail(int id, [FromBody] PatchEmailDto dto)
    {
        try
        {
            var updated = await _userService.PatchEmailAsync(id, dto);
            if (updated == null)
            {
                return NotFound(new { Message = $"User with ID {id} was not found." });
            }
            return Ok(new { Message = "User email updated successfully.", User = updated });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    /// <summary>
    /// DELETE /api/User/{id} - Delete user account by ID (REST Verb: DELETE)
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _userService.DeleteUserAsync(id);
        if (!result)
        {
            return NotFound(new { Message = $"User with ID {id} was not found." });
        }
        return Ok(new { Message = $"User with ID {id} was successfully deleted." });
    }

    /// <summary>
    /// GET /api/User/quote - Consume external API using HttpClient (Day 12 HttpClient Demo)
    /// </summary>
    [HttpGet("quote")]
    public async Task<IActionResult> GetQuote()
    {
        var quote = await _quoteService.GetDailyInspirationalQuoteAsync();
        return Ok(new { Message = "External quote consumed via HttpClient", Data = quote });
    }
}
