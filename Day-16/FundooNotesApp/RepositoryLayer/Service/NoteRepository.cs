using Microsoft.EntityFrameworkCore;
using ModelLayer;
using ModelLayer.Context;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service;

/// <summary>
/// Day-15: NoteRepository — EF Core data access for Notes.
/// Day-16: All queries now eagerly load NoteLabels → Label for the DTO mapper.
/// </summary>
public class NoteRepository : INoteRepository
{
    private readonly FundooDbContext _context;

    public NoteRepository(FundooDbContext context) => _context = context;

    /// <summary>Creates a new note for the authenticated user.</summary>
    public async Task<Note> CreateNoteAsync(Note note)
    {
        note.CreatedAt = DateTime.UtcNow;
        note.UpdatedAt = DateTime.UtcNow;
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
        return note;
    }

    /// <summary>
    /// Retrieves all active (non-trashed, non-archived) notes for the user.
    /// Pinned notes appear first, then by latest created.
    /// Day-16: Eagerly loads NoteLabels → Label.
    /// </summary>
    public async Task<List<Note>> GetAllNotesByUserAsync(int userId) =>
        await _context.Notes
            .AsNoTracking()
            .Where(n => n.UserId == userId && !n.IsTrashed && !n.IsArchived)
            .Include(n => n.User)
            .Include(n => n.NoteLabels)
                .ThenInclude(nl => nl.Label)
            .OrderByDescending(n => n.IsPinned)  // pinned first
            .ThenByDescending(n => n.CreatedAt)
            .ToListAsync();

    /// <summary>Gets a single note by Id (ownership validated in BL). Loads NoteLabels.</summary>
    public async Task<Note?> GetNoteByIdAsync(int noteId) =>
        await _context.Notes
            .Include(n => n.User)
            .Include(n => n.NoteLabels)
                .ThenInclude(nl => nl.Label)
            .FirstOrDefaultAsync(n => n.Id == noteId);

    /// <summary>Updates an existing note.</summary>
    public async Task<Note> UpdateNoteAsync(Note note)
    {
        note.UpdatedAt = DateTime.UtcNow;
        _context.Notes.Update(note);
        await _context.SaveChangesAsync();
        return note;
    }

    /// <summary>Permanently deletes a note — ownership validated.</summary>
    public async Task<bool> DeleteNoteAsync(int noteId, int userId)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(n => n.Id == noteId && n.UserId == userId);

        if (note == null) return false;

        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();
        return true;
    }

    // ── Day-15: Pin / Archive / Trash / Search ────────────────────────────────

    /// <summary>
    /// Toggles the IsPinned flag on a note.
    /// LINQ: Find by Id + UserId, flip boolean, save.
    /// </summary>
    public async Task<Note?> TogglePinAsync(int noteId, int userId)
    {
        var note = await _context.Notes
            .Include(n => n.NoteLabels).ThenInclude(nl => nl.Label)
            .FirstOrDefaultAsync(n => n.Id == noteId && n.UserId == userId);

        if (note == null) return null;

        note.IsPinned  = !note.IsPinned;   // toggle
        note.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return note;
    }

    /// <summary>
    /// Toggles the IsArchived flag on a note.
    /// Archiving also unpins the note.
    /// </summary>
    public async Task<Note?> ToggleArchiveAsync(int noteId, int userId)
    {
        var note = await _context.Notes
            .Include(n => n.NoteLabels).ThenInclude(nl => nl.Label)
            .FirstOrDefaultAsync(n => n.Id == noteId && n.UserId == userId);

        if (note == null) return null;

        note.IsArchived = !note.IsArchived;
        if (note.IsArchived) note.IsPinned = false; // unpin when archiving
        note.UpdatedAt  = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return note;
    }

    /// <summary>
    /// Toggles the IsTrashed flag (soft delete).
    /// Trashing also unpins and unarchives the note.
    /// </summary>
    public async Task<Note?> ToggleTrashAsync(int noteId, int userId)
    {
        var note = await _context.Notes
            .Include(n => n.NoteLabels).ThenInclude(nl => nl.Label)
            .FirstOrDefaultAsync(n => n.Id == noteId && n.UserId == userId);

        if (note == null) return null;

        note.IsTrashed  = !note.IsTrashed;
        if (note.IsTrashed)
        {
            note.IsPinned   = false; // unpin when trashing
            note.IsArchived = false; // unarchive when trashing
        }
        note.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return note;
    }

    /// <summary>
    /// Searches notes by title or description using LINQ Contains.
    /// Case-insensitive. Returns only non-trashed notes of the user.
    /// Day-16: Loads NoteLabels → Label.
    /// </summary>
    public async Task<List<Note>> SearchNotesAsync(int userId, string query)
    {
        var lowerQuery = query.ToLower().Trim();

        return await _context.Notes
            .AsNoTracking()
            .Where(n => n.UserId == userId
                     && !n.IsTrashed
                     && (n.Title.ToLower().Contains(lowerQuery)
                      || (n.Description != null && n.Description.ToLower().Contains(lowerQuery))))
            .Include(n => n.User)
            .Include(n => n.NoteLabels)
                .ThenInclude(nl => nl.Label)
            .OrderByDescending(n => n.IsPinned)
            .ThenByDescending(n => n.CreatedAt)
            .ToListAsync();
    }
}
