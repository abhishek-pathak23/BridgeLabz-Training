using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace FundooNotesApp.Controllers;

/// <summary>
/// Day-16: LabelsController — Tags/Labels management module.
///
/// Endpoints:
///   POST   /api/labels               — Create a new label
///   GET    /api/labels               — Get all labels for the authenticated user
///   GET    /api/labels/{id}          — Get a label by Id
///   PUT    /api/labels/{id}          — Update a label
///   DELETE /api/labels/{id}          — Delete a label
///   POST   /api/labels/{id}/notes/{noteId}   — Assign label to note
///   DELETE /api/labels/{id}/notes/{noteId}   — Remove label from note
///   GET    /api/labels/{id}/notes            — Get all notes with this label
///
/// All endpoints require JWT authentication.
/// UserId is extracted from JWT 'sub' claim via ICurrentUserService.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LabelsController : ControllerBase
{
    private readonly ILabelService       _labelService;
    private readonly ICurrentUserService _currentUserService;

    public LabelsController(ILabelService labelService, ICurrentUserService currentUserService)
    {
        _labelService       = labelService;
        _currentUserService = currentUserService;
    }

    // ── POST /api/labels ──────────────────────────────────────────────────────

    /// <summary>
    /// Create a new label (tag) for the authenticated user.
    /// </summary>
    /// <param name="dto">Label name and optional hex color.</param>
    /// <returns>The newly created label.</returns>
    /// <response code="201">Label created successfully.</response>
    /// <response code="400">Validation error.</response>
    /// <response code="401">JWT token missing or invalid.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateLabel([FromBody] CreateLabelDto dto)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            var label = await _labelService.CreateLabelAsync(dto, userId.Value);
            return CreatedAtAction(nameof(GetLabelById), new { id = label.Id }, new
            {
                Message = "Label created successfully.",
                Label   = label
            });
        }
        catch (Exception ex) { return BadRequest(new { Message = ex.Message }); }
    }

    // ── GET /api/labels ───────────────────────────────────────────────────────

    /// <summary>
    /// Get all labels belonging to the authenticated user.
    /// Returns labels ordered alphabetically by name.
    /// </summary>
    /// <response code="200">List of labels returned.</response>
    /// <response code="401">JWT token missing or invalid.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetAllLabels()
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        var labels = await _labelService.GetAllLabelsAsync(userId.Value);
        return Ok(new
        {
            Message     = $"Labels for user (UserId: {userId}).",
            TotalLabels = labels.Count,
            Labels      = labels
        });
    }

    // ── GET /api/labels/{id} ──────────────────────────────────────────────────

    /// <summary>
    /// Get a single label by Id. Validates that the label belongs to the authenticated user.
    /// </summary>
    /// <param name="id">Label Id.</param>
    /// <response code="200">Label returned.</response>
    /// <response code="404">Label not found or not owned by user.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetLabelById(int id)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            var label = await _labelService.GetLabelByIdAsync(id, userId.Value);
            return Ok(label);
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
    }

    // ── PUT /api/labels/{id} ──────────────────────────────────────────────────

    /// <summary>
    /// Update a label's name and/or color.
    /// </summary>
    /// <param name="id">Label Id to update.</param>
    /// <param name="dto">New name and color.</param>
    /// <response code="200">Label updated.</response>
    /// <response code="404">Label not found.</response>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateLabel(int id, [FromBody] UpdateLabelDto dto)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            var updated = await _labelService.UpdateLabelAsync(id, dto, userId.Value);
            return Ok(new { Message = $"Label (Id: {id}) updated.", Label = updated });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
        catch (Exception ex)            { return BadRequest(new { Message = ex.Message }); }
    }

    // ── DELETE /api/labels/{id} ───────────────────────────────────────────────

    /// <summary>
    /// Delete a label. This will also remove all NoteLabel assignments for this label.
    /// </summary>
    /// <param name="id">Label Id to delete.</param>
    /// <response code="200">Label deleted.</response>
    /// <response code="404">Label not found.</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteLabel(int id)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            await _labelService.DeleteLabelAsync(id, userId.Value);
            return Ok(new { Message = $"Label (Id: {id}) deleted successfully." });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
    }

    // ── POST /api/labels/{id}/notes/{noteId} ──────────────────────────────────

    /// <summary>
    /// Assign a label to a note.
    /// Both the label and note must belong to the authenticated user.
    /// This operation is idempotent — assigning an already-assigned label is safe.
    /// </summary>
    /// <param name="id">Label Id.</param>
    /// <param name="noteId">Note Id.</param>
    /// <response code="200">Label assigned to note.</response>
    /// <response code="404">Label or note not found.</response>
    [HttpPost("{id:int}/notes/{noteId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AssignLabelToNote(int id, int noteId)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            await _labelService.AssignLabelToNoteAsync(noteId, id, userId.Value);
            return Ok(new { Message = $"Label (Id: {id}) assigned to Note (Id: {noteId}) successfully." });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
    }

    // ── DELETE /api/labels/{id}/notes/{noteId} ────────────────────────────────

    /// <summary>
    /// Remove a label from a note.
    /// </summary>
    /// <param name="id">Label Id.</param>
    /// <param name="noteId">Note Id.</param>
    /// <response code="200">Label removed from note.</response>
    /// <response code="404">Label or note not found / not assigned.</response>
    [HttpDelete("{id:int}/notes/{noteId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveLabelFromNote(int id, int noteId)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            await _labelService.RemoveLabelFromNoteAsync(noteId, id, userId.Value);
            return Ok(new { Message = $"Label (Id: {id}) removed from Note (Id: {noteId}) successfully." });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
    }

    // ── GET /api/labels/{id}/notes ────────────────────────────────────────────

    /// <summary>
    /// Get all notes that have the specified label assigned.
    /// Returns only non-trashed notes of the authenticated user.
    /// Pinned notes appear first.
    /// </summary>
    /// <param name="id">Label Id.</param>
    /// <response code="200">Notes with this label returned.</response>
    /// <response code="404">Label not found.</response>
    [HttpGet("{id:int}/notes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNotesByLabel(int id)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Unauthorized(new { Message = "Unable to extract UserId from JWT." });

        try
        {
            var notes = await _labelService.GetNotesByLabelAsync(id, userId.Value);
            return Ok(new
            {
                Message      = $"Notes with Label (Id: {id}).",
                TotalResults = notes.Count,
                Notes        = notes
            });
        }
        catch (KeyNotFoundException ex) { return NotFound(new { Message = ex.Message }); }
    }
}
