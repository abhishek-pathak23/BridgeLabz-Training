using ModelLayer;

namespace RepositoryLayer.Interface;

/// <summary>
/// Day-14: Notes data access contract.
/// </summary>
public interface INoteRepository
{
    Task<Note> CreateNoteAsync(Note note);
    Task<List<Note>> GetAllNotesByUserAsync(int userId);
    Task<Note?> GetNoteByIdAsync(int noteId);
    Task<bool> DeleteNoteAsync(int noteId, int userId);
}
