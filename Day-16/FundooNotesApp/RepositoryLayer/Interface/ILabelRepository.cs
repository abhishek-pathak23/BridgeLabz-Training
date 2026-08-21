using ModelLayer;

namespace RepositoryLayer.Interface;

/// <summary>
/// Day-16: Labels data access contract.
/// Full CRUD for Labels + Note assignment (many-to-many via NoteLabel join table).
/// </summary>
public interface ILabelRepository
{
    // ── Label CRUD ────────────────────────────────────────────────────────────
    Task<Label>       CreateLabelAsync(Label label);
    Task<List<Label>> GetAllLabelsByUserAsync(int userId);
    Task<Label?>      GetLabelByIdAsync(int labelId);
    Task<Label>       UpdateLabelAsync(Label label);
    Task<bool>        DeleteLabelAsync(int labelId, int userId);

    // ── Note Assignment ───────────────────────────────────────────────────────
    /// <summary>Assigns a label to a note (adds NoteLabel row if not already assigned).</summary>
    Task<bool>       AssignLabelToNoteAsync(int noteId, int labelId, int userId);

    /// <summary>Removes a label from a note (deletes NoteLabel row).</summary>
    Task<bool>       RemoveLabelFromNoteAsync(int noteId, int labelId, int userId);

    /// <summary>Gets all notes that have the specified label (for the authenticated user).</summary>
    Task<List<Note>> GetNotesByLabelAsync(int labelId, int userId);
}
