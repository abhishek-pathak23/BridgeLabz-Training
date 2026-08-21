namespace FundooNotesApp.Controllers;

using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Day-14: AuthZ (Role-Based Authorization) - Only Admins can see all users.
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    /// <summary>
    /// Day-14: AuthZ - Any authenticated user can get their own profile.
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMyProfile()
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        if (!int.TryParse(userIdString, out var userId))
        {
            return Unauthorized(new { Message = "User ID not found in token." });
        }

        var profile = await _userService.GetUserByIdAsync(userId);
        if (profile == null) return NotFound("User not found.");

        return Ok(profile);
    }

    /// <summary>
    /// Day-14: AuthZ - Only Admins can view specific users by ID.
    /// </summary>
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound($"User with ID {id} not found.");
        return Ok(user);
    }

    /// <summary>
    /// Day-14: AuthZ - Users can update their own profile.
    /// </summary>
    [HttpPut("me")]
    [Authorize]
    public async Task<IActionResult> UpdateMyProfile([FromBody] UpdateProfileDto dto)
    {
        var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        if (!int.TryParse(userIdString, out var userId))
        {
            return Unauthorized(new { Message = "User ID not found in token." });
        }

        var updatedProfile = await _userService.UpdateUserAsync(userId, dto);
        if (updatedProfile == null) return NotFound("User not found.");

        return Ok(updatedProfile);
    }

    /// <summary>
    /// Day-14: AuthZ - Only Admins can delete users.
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var success = await _userService.DeleteUserAsync(id);
        if (!success) return NotFound($"User with ID {id} not found.");

        return Ok(new { Message = $"User {id} deleted successfully." });
    }
}
