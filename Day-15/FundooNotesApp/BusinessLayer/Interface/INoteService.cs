using ModelLayer;

namespace BusinessLayer.Interface;

/// <summary>
/// Day-15: Notes service contract.
/// Includes Pin, Archive, Trash (soft-delete), and Search operations.
/// </summary>
public interface INoteService
{
    Task<NoteResponseDto> CreateNoteAsync(CreateNoteDto dto, int userId, string userEmail);
    Task<List<NoteResponseDto>> GetAllNotesAsync(int userId);
    Task<NoteResponseDto> GetNoteByIdAsync(int noteId, int userId);
    Task<NoteResponseDto> UpdateNoteAsync(int noteId, UpdateNoteDto dto, int userId);
    Task<bool> DeleteNoteAsync(int noteId, int userId);

    // ── Day-15 Operations ─────────────────────────────────────────────────────
    Task<NoteResponseDto> TogglePinAsync(int noteId, int userId);
    Task<NoteResponseDto> ToggleArchiveAsync(int noteId, int userId);
    Task<NoteResponseDto> ToggleTrashAsync(int noteId, int userId);
    Task<List<NoteResponseDto>> SearchNotesAsync(int userId, string query);
}
