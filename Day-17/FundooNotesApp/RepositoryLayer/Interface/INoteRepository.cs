using ModelLayer;

namespace RepositoryLayer.Interface;

/// <summary>
/// Day-15: Notes data access contract.
/// Includes Pin, Archive, Trash (soft-delete), and Search operations.
/// </summary>
public interface INoteRepository
{
    Task<Note> CreateNoteAsync(Note note);
    Task<List<Note>> GetAllNotesByUserAsync(int userId);
    Task<Note?> GetNoteByIdAsync(int noteId);
    Task<Note> UpdateNoteAsync(Note note);
    Task<bool> DeleteNoteAsync(int noteId, int userId);

    // ── Day-15 Operations ─────────────────────────────────────────────────────
    Task<Note?> TogglePinAsync(int noteId, int userId);
    Task<Note?> ToggleArchiveAsync(int noteId, int userId);
    Task<Note?> ToggleTrashAsync(int noteId, int userId);
    Task<List<Note>> SearchNotesAsync(int userId, string query);
}
