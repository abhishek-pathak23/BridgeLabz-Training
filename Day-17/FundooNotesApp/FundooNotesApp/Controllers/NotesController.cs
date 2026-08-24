using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace FundooNotesApp.Controllers;

/// <summary>
/// Day-15: NotesController — Full Notes CRUD + Pin / Archive / Trash / Search.
///
/// All endpoints require JWT authentication ([Authorize]).
/// UserId is extracted from JWT 'sub' claim via ICurrentUserService — never passed in URL.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NotesController : ControllerBase
{
    private readonly INoteService        _noteService;
    private readonly ICurrentUserService _currentUserService;

    public NotesController(INoteService noteService, ICurrentUserService currentUserService)
    {
        _noteService        = noteService;
        _currentUserService = currentUserService;
    }

    // ── POST /api/notes ───────────────────────────────────────────────────────

    /// <summary>Create a new note. UserId + Email are auto-extracted from JWT claims.</summary>
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
                Message    = "Note created successfully.",
                ClaimsUsed = new { UserId = userId, Email = email },
                Note       = note
            });
        }
        catch (Exception ex) { return BadRequest(new { Message = ex.Message }); }
    }

    // ── GET /api/notes ────────────────────────────────────────────────────────

    /// <summary>
    /// Retrieve all active (non-trashed) notes for the authenticated user.
    /// Pinned notes appear at the top.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllNotes()
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        var notes = await _noteService.GetAllNotesAsync(userId.Value);
        return Ok(new
        {
            Message    = $"Notes for user (UserId: {userId}).",
            TotalNotes = notes.Count,
            Notes      = notes
        });
    }

    // ── GET /api/notes/{id} ───────────────────────────────────────────────────

    /// <summary>Retrieve a single note by Id. Validates ownership.</summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetNoteById(int id)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            var note = await _noteService.GetNoteByIdAsync(id, userId.Value);
            return Ok(note);
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
    }

    // ── PUT /api/notes/{id} ───────────────────────────────────────────────────

    /// <summary>Update title and description of a note. Validates ownership.</summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateNote(int id, [FromBody] UpdateNoteDto dto)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            var updated = await _noteService.UpdateNoteAsync(id, dto, userId.Value);
            return Ok(new { Message = $"Note (Id: {id}) updated.", Note = updated });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
        catch (Exception ex)            { return BadRequest(new { Message = ex.Message }); }
    }

    // ── DELETE /api/notes/{id} ────────────────────────────────────────────────

    /// <summary>Permanently delete a note. Validates ownership.</summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            await _noteService.DeleteNoteAsync(id, userId.Value);
            return Ok(new { Message = $"Note (Id: {id}) permanently deleted." });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
        catch (Exception ex)            { return BadRequest(new { Message = ex.Message }); }
    }

    // ── PATCH /api/notes/{id}/pin ─────────────────────────────────────────────

    /// <summary>
    /// Toggle Pin on a note.
    /// Pinned = true → note appears at the top of GET /api/notes list.
    /// Pinned = false → note returns to normal order.
    /// </summary>
    [HttpPatch("{id:int}/pin")]
    public async Task<IActionResult> TogglePin(int id)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            var note = await _noteService.TogglePinAsync(id, userId.Value);
            var status = note.IsPinned ? "pinned" : "unpinned";
            return Ok(new { Message = $"Note (Id: {id}) {status} successfully.", Note = note });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
    }

    // ── PATCH /api/notes/{id}/archive ─────────────────────────────────────────

    /// <summary>
    /// Toggle Archive on a note.
    /// Archived = true → note is hidden from main list.
    /// Archived = false → note is restored to main list.
    /// Archiving also unpins the note.
    /// </summary>
    [HttpPatch("{id:int}/archive")]
    public async Task<IActionResult> ToggleArchive(int id)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            var note   = await _noteService.ToggleArchiveAsync(id, userId.Value);
            var status = note.IsArchived ? "archived" : "unarchived";
            return Ok(new { Message = $"Note (Id: {id}) {status} successfully.", Note = note });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
    }

    // ── PATCH /api/notes/{id}/trash ───────────────────────────────────────────

    /// <summary>
    /// Toggle Trash (soft-delete) on a note.
    /// Trashed = true → note is moved to trash (NOT permanently deleted).
    /// Trashed = false → note is restored from trash.
    /// Trashing also unpins and unarchives the note.
    /// </summary>
    [HttpPatch("{id:int}/trash")]
    public async Task<IActionResult> ToggleTrash(int id)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            var note   = await _noteService.ToggleTrashAsync(id, userId.Value);
            var status = note.IsTrashed ? "moved to trash" : "restored from trash";
            return Ok(new { Message = $"Note (Id: {id}) {status} successfully.", Note = note });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
    }

    // ── GET /api/notes/search?q=abc ───────────────────────────────────────────

    /// <summary>
    /// Search notes by title or description.
    /// Example: GET /api/notes/search?q=a  → returns all notes where title/description contains "a".
    /// Only searches non-trashed notes of the authenticated user.
    /// </summary>
    [HttpGet("search")]
    public async Task<IActionResult> SearchNotes([FromQuery] string q)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        if (string.IsNullOrWhiteSpace(q))
            return BadRequest(new { Message = "Search query 'q' cannot be empty." });

        try
        {
            var notes = await _noteService.SearchNotesAsync(userId.Value, q);
            return Ok(new
            {
                Message      = $"Search results for '{q}'.",
                TotalResults = notes.Count,
                Notes        = notes
            });
        }
        catch (ArgumentException ex) { return BadRequest(new { Message = ex.Message }); }
    }

    // ── POST /api/notes/{id}/reminder ─────────────────────────────────────────

    /// <summary>
    /// Day-17: Add or update a reminder for a note.
    /// Expects a JSON body with the reminder date, or null to remove it.
    /// </summary>
    [HttpPost("{id:int}/reminder")]
    public async Task<IActionResult> AddOrUpdateReminder(int id, [FromBody] DateTime? reminder)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            var note = await _noteService.AddOrUpdateReminderAsync(id, userId.Value, reminder);
            return Ok(new { Message = $"Reminder updated for Note (Id: {id}).", Note = note });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
        catch (Exception ex)            { return BadRequest(new { Message = ex.Message }); }
    }
}
