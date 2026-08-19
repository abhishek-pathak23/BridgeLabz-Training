using Microsoft.EntityFrameworkCore;
using ModelLayer;
using ModelLayer.Context;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service;

/// <summary>
/// Day-14: NoteRepository — EF Core data access for Notes.
/// UserId is extracted from JWT claims by the business layer and passed in.
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
    /// Retrieves all notes belonging to the given userId (from JWT claim 'sub').
    /// </summary>
    public async Task<List<Note>> GetAllNotesByUserAsync(int userId) =>
        await _context.Notes
            .AsNoTracking()
            .Where(n => n.UserId == userId)
            .Include(n => n.User)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();

    /// <summary>Gets a single note by Id (ownership not validated here — validated in BL).</summary>
    public async Task<Note?> GetNoteByIdAsync(int noteId) =>
        await _context.Notes
            .Include(n => n.User)
            .FirstOrDefaultAsync(n => n.Id == noteId);

    /// <summary>Updates an existing note.</summary>
    public async Task<Note> UpdateNoteAsync(Note note)
    {
        note.UpdatedAt = DateTime.UtcNow;
        _context.Notes.Update(note);
        await _context.SaveChangesAsync();
        return note;
    }

    /// <summary>
    /// Deletes a note only if it belongs to the given userId (from JWT claim 'sub').
    /// Prevents cross-user deletion.
    /// </summary>
    public async Task<bool> DeleteNoteAsync(int noteId, int userId)
    {
        var note = await _context.Notes
            .FirstOrDefaultAsync(n => n.Id == noteId && n.UserId == userId);

        if (note == null)
            return false;

        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();
        return true;
    }
}
