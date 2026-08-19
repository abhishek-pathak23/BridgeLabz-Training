using ModelLayer;

namespace BusinessLayer.Interface;

/// <summary>
/// Day-14: Notes service contract.
/// </summary>
public interface INoteService
{
    /// <summary>Create a note. UserId + Email are extracted from JWT claims.</summary>
    Task<NoteResponseDto> CreateNoteAsync(CreateNoteDto dto, int userId, string userEmail);

    /// <summary>Get all notes for the authenticated user (userId from JWT).</summary>
    Task<List<NoteResponseDto>> GetAllNotesAsync(int userId);

    /// <summary>Get a single note. Validates ownership via userId from JWT.</summary>
    Task<NoteResponseDto> GetNoteByIdAsync(int noteId, int userId);

    /// <summary>Update a note. Validates ownership via userId from JWT.</summary>
    Task<NoteResponseDto> UpdateNoteAsync(int noteId, UpdateNoteDto dto, int userId);

    /// <summary>Delete a note. Validates ownership via userId from JWT.</summary>
    Task<bool> DeleteNoteAsync(int noteId, int userId);
}
