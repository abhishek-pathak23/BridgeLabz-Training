using Microsoft.EntityFrameworkCore;
using ModelLayer;
using ModelLayer.Context;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service;

/// <summary>
/// Day-16: LabelRepository — EF Core data access for Labels.
/// Implements CRUD for Labels and many-to-many assignment to Notes.
/// </summary>
public class LabelRepository : ILabelRepository
{
    private readonly FundooDbContext _context;

    public LabelRepository(FundooDbContext context) => _context = context;

    // ── Label CRUD ────────────────────────────────────────────────────────────

    /// <summary>Creates a new label for the authenticated user.</summary>
    public async Task<Label> CreateLabelAsync(Label label)
    {
        label.CreatedAt = DateTime.UtcNow;
        label.UpdatedAt = DateTime.UtcNow;
        _context.Labels.Add(label);
        await _context.SaveChangesAsync();
        return label;
    }

    /// <summary>Returns all labels belonging to the user, ordered alphabetically.</summary>
    public async Task<List<Label>> GetAllLabelsByUserAsync(int userId) =>
        await _context.Labels
            .AsNoTracking()
            .Where(l => l.UserId == userId)
            .OrderBy(l => l.Name)
            .ToListAsync();

    /// <summary>Gets a single label by Id (ownership validated in BL).</summary>
    public async Task<Label?> GetLabelByIdAsync(int labelId) =>
        await _context.Labels
            .Include(l => l.NoteLabels)
            .FirstOrDefaultAsync(l => l.Id == labelId);

    /// <summary>Updates an existing label.</summary>
    public async Task<Label> UpdateLabelAsync(Label label)
    {
        label.UpdatedAt = DateTime.UtcNow;
        _context.Labels.Update(label);
        await _context.SaveChangesAsync();
        return label;
    }

    /// <summary>Deletes a label — cascades to remove NoteLabel join rows.</summary>
    public async Task<bool> DeleteLabelAsync(int labelId, int userId)
    {
        var label = await _context.Labels
            .FirstOrDefaultAsync(l => l.Id == labelId && l.UserId == userId);

        if (label == null) return false;

        _context.Labels.Remove(label);
        await _context.SaveChangesAsync();
        return true;
    }

    // ── Note Assignment ───────────────────────────────────────────────────────

    /// <summary>
    /// Assigns a label to a note. Both the note and label must belong to the user.
    /// Idempotent — does nothing if already assigned.
    /// </summary>
    public async Task<bool> AssignLabelToNoteAsync(int noteId, int labelId, int userId)
    {
        // Verify ownership
        var noteExists  = await _context.Notes.AnyAsync(n => n.Id == noteId  && n.UserId == userId);
        var labelExists = await _context.Labels.AnyAsync(l => l.Id == labelId && l.UserId == userId);

        if (!noteExists || !labelExists) return false;

        // Idempotency check — don't duplicate
        var alreadyAssigned = await _context.NoteLabels
            .AnyAsync(nl => nl.NoteId == noteId && nl.LabelId == labelId);

        if (alreadyAssigned) return true;

        _context.NoteLabels.Add(new NoteLabel { NoteId = noteId, LabelId = labelId });
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>Removes a label from a note. Both must belong to the user.</summary>
    public async Task<bool> RemoveLabelFromNoteAsync(int noteId, int labelId, int userId)
    {
        // Verify ownership
        var noteExists  = await _context.Notes.AnyAsync(n => n.Id == noteId  && n.UserId == userId);
        var labelExists = await _context.Labels.AnyAsync(l => l.Id == labelId && l.UserId == userId);

        if (!noteExists || !labelExists) return false;

        var noteLabel = await _context.NoteLabels
            .FirstOrDefaultAsync(nl => nl.NoteId == noteId && nl.LabelId == labelId);

        if (noteLabel == null) return false;

        _context.NoteLabels.Remove(noteLabel);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Gets all non-trashed notes that have the specified label for the user.
    /// Uses LINQ join via NoteLabels join table.
    /// </summary>
    public async Task<List<Note>> GetNotesByLabelAsync(int labelId, int userId) =>
        await _context.Notes
            .AsNoTracking()
            .Where(n => n.UserId == userId
                     && !n.IsTrashed
                     && n.NoteLabels.Any(nl => nl.LabelId == labelId))
            .Include(n => n.User)
            .Include(n => n.NoteLabels)
                .ThenInclude(nl => nl.Label)
            .OrderByDescending(n => n.IsPinned)
            .ThenByDescending(n => n.CreatedAt)
            .ToListAsync();
}
