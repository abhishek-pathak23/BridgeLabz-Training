using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace FundooNotesApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors("FundooFrontendPolicy")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IExternalQuoteService _quoteService;
    private readonly ICurrentUserService _currentUserService;

    public UserController(
        IUserService userService,
        IExternalQuoteService quoteService,
        ICurrentUserService currentUserService)
    {
        _userService = userService;
        _quoteService = quoteService;
        _currentUserService = currentUserService;
    }

    /// <summary>
    /// GET /api/User - Get all users (Restricted to Admin role)
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    /// <summary>
    /// GET /api/User/{id} - Get user by ID with route constraint (id >= 1)
    /// </summary>
    [HttpGet("{id:int:min(1)}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        // Non-admin users can only view their own profile
        if (_currentUserService.Role != "Admin" && _currentUserService.UserId != id)
        {
            return Forbid();
        }

        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound(new { Message = $"User with ID {id} was not found." });
        }
        return Ok(user);
    }

    /// <summary>
    /// PUT /api/User/{id} - Update user profile with route constraint
    /// </summary>
    [HttpPut("{id:int:min(1)}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
    {
        if (_currentUserService.Role != "Admin" && _currentUserService.UserId != id)
        {
            return Forbid();
        }

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
    /// PATCH /api/User/{id}/email - Partial update of user email
    /// </summary>
    [HttpPatch("{id:int:min(1)}/email")]
    [Authorize]
    public async Task<IActionResult> PatchEmail(int id, [FromBody] PatchEmailDto dto)
    {
        if (_currentUserService.Role != "Admin" && _currentUserService.UserId != id)
        {
            return Forbid();
        }

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
    /// DELETE /api/User/{id} - Delete user account (Admin only)
    /// </summary>
    [HttpDelete("{id:int:min(1)}")]
    [Authorize(Roles = "Admin")]
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
    /// GET /api/User/quote - Public endpoint consuming external REST API via HttpClient
    /// </summary>
    [HttpGet("quote")]
    [AllowAnonymous]
    public async Task<IActionResult> GetQuote()
    {
        var quote = await _quoteService.GetDailyInspirationalQuoteAsync();
        return Ok(new { Message = "External quote consumed via HttpClient", Data = quote });
    }
}
