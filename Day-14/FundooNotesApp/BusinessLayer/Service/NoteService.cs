using BusinessLayer.Interface;
using ModelLayer;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service;

/// <summary>
/// Day-14: NoteService — business logic for Notes management.
/// UserId is always extracted from JWT claims (passed in from controller).
/// This ensures notes are scoped to the authenticated user.
/// </summary>
public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    /// <summary>
    /// Creates a note.
    /// UserId comes from JWT 'sub' claim — guaranteed by [Authorize] middleware.
    /// Email comes from JWT 'email' claim — stored for reference/display.
    /// </summary>
    public async Task<NoteResponseDto> CreateNoteAsync(CreateNoteDto dto, int userId, string userEmail)
    {
        var note = new Note
        {
            Title       = dto.Title.Trim(),
            Description = dto.Description?.Trim(),
            UserId      = userId     // ← from JWT sub claim
        };

        var created = await _noteRepository.CreateNoteAsync(note);

        return ToResponseDto(created, userEmail);
    }

    /// <summary>
    /// Returns all notes for the authenticated user.
    /// UserId from JWT 'sub' claim filters the result — users only see their own notes.
    /// </summary>
    public async Task<List<NoteResponseDto>> GetAllNotesAsync(int userId)
    {
        var notes = await _noteRepository.GetAllNotesByUserAsync(userId);

        return notes.Select(n => ToResponseDto(n, n.User?.Email ?? string.Empty)).ToList();
    }

    /// <summary>
    /// Deletes a note.
    /// UserId from JWT claim ensures only the note's owner can delete it.
    /// </summary>
    public async Task<bool> DeleteNoteAsync(int noteId, int userId)
    {
        var deleted = await _noteRepository.DeleteNoteAsync(noteId, userId);
        if (!deleted)
            throw new KeyNotFoundException($"Note with Id {noteId} not found or does not belong to the current user.");

        return true;
    }

    private static NoteResponseDto ToResponseDto(Note n, string userEmail) => new()
    {
        Id          = n.Id,
        Title       = n.Title,
        Description = n.Description,
        UserId      = n.UserId,
        UserEmail   = userEmail,
        CreatedAt   = n.CreatedAt,
        UpdatedAt   = n.UpdatedAt
    };
}
