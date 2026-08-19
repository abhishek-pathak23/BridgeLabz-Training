using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace FundooNotesApp.Controllers;

/// <summary>
/// Day-14: NotesController — Notes Management Module.
///
/// All endpoints require JWT authentication ([Authorize]).
/// UserId and Email are extracted from JWT claims automatically via ICurrentUserService.
///
/// This demonstrates the core Day-14 requirement:
///   • Claims-based identity: sub=UserId identifies the owner of each note
///   • Email claim: used for display/response (human-readable)
///   • Name is NOT used for identity (can be shared/changed)
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]   // All notes endpoints require a valid JWT token
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;
    private readonly ICurrentUserService _currentUserService;

    public NotesController(INoteService noteService, ICurrentUserService currentUserService)
    {
        _noteService        = noteService;
        _currentUserService = currentUserService;
    }

    // ── POST /api/notes ───────────────────────────────────────────────────────

    /// <summary>
    /// Create a new note for the authenticated user.
    /// UserId (from JWT 'sub' claim) and Email (from JWT 'email' claim) are
    /// automatically extracted — no need to pass them in the request body.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateNote([FromBody] CreateNoteDto dto)
    {
        var userId = _currentUserService.UserId;
        var email  = _currentUserService.Email;

        if (userId == null || email == null)
            return Unauthorized(new { Message = "Unable to extract UserId/Email from JWT claims." });

        try
        {
            var note = await _noteService.CreateNoteAsync(dto, userId.Value, email);
            return CreatedAtAction(nameof(GetAllNotes), new { }, new
            {
                Message     = "Note created successfully.",
                ClaimsUsed  = new { UserId = userId, Email = email },   // show which JWT claims were used
                Note        = note
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    // ── GET /api/notes ────────────────────────────────────────────────────────

    /// <summary>
    /// Retrieve all notes for the currently authenticated user.
    /// Notes are filtered by UserId extracted from JWT 'sub' claim.
    /// Users can only see their own notes.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllNotes()
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT 'sub' claim." });

        var notes = await _noteService.GetAllNotesAsync(userId.Value);

        return Ok(new
        {
            Message    = $"Notes retrieved for authenticated user (UserId from JWT sub claim: {userId}).",
            TotalNotes = notes.Count,
            Notes      = notes
        });
    }

    // ── DELETE /api/notes/{id} ────────────────────────────────────────────────

    /// <summary>
    /// Delete a note by Id.
    /// Ownership is validated using UserId from JWT 'sub' claim —
    /// a user cannot delete another user's note.
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT 'sub' claim." });

        try
        {
            await _noteService.DeleteNoteAsync(id, userId.Value);
            return Ok(new
            {
                Message    = $"Note (Id: {id}) deleted successfully.",
                DeletedBy  = new { UserId = userId, Email = _currentUserService.Email }
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
}
