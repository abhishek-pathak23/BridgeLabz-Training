using BusinessLayer.Interface;
using ModelLayer;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service;

/// <summary>
/// Day-15: NoteService — business logic for Notes management.
/// Adds Pin, Archive, Trash (soft-delete), and Search operations.
/// UserId is always extracted from JWT claims (passed from controller).
/// </summary>
public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<NoteResponseDto> CreateNoteAsync(CreateNoteDto dto, int userId, string userEmail)
    {
        var note = new Note
        {
            Title       = dto.Title.Trim(),
            Description = dto.Description?.Trim(),
            UserId      = userId
        };

        var created = await _noteRepository.CreateNoteAsync(note);
        return ToResponseDto(created, userEmail);
    }

    public async Task<List<NoteResponseDto>> GetAllNotesAsync(int userId)
    {
        var notes = await _noteRepository.GetAllNotesByUserAsync(userId);
        return notes.Select(n => ToResponseDto(n, n.User?.Email ?? string.Empty)).ToList();
    }

    public async Task<NoteResponseDto> GetNoteByIdAsync(int noteId, int userId)
    {
        var note = await _noteRepository.GetNoteByIdAsync(noteId);
        if (note == null || note.UserId != userId)
            throw new KeyNotFoundException($"Note with Id {noteId} not found or does not belong to you.");

        return ToResponseDto(note, note.User?.Email ?? string.Empty);
    }

    public async Task<NoteResponseDto> UpdateNoteAsync(int noteId, UpdateNoteDto dto, int userId)
    {
        var note = await _noteRepository.GetNoteByIdAsync(noteId);
        if (note == null || note.UserId != userId)
            throw new KeyNotFoundException($"Note with Id {noteId} not found or does not belong to you.");

        note.Title       = dto.Title.Trim();
        note.Description = dto.Description?.Trim();

        var updated = await _noteRepository.UpdateNoteAsync(note);
        return ToResponseDto(updated, updated.User?.Email ?? string.Empty);
    }

    public async Task<bool> DeleteNoteAsync(int noteId, int userId)
    {
        var deleted = await _noteRepository.DeleteNoteAsync(noteId, userId);
        if (!deleted)
            throw new KeyNotFoundException($"Note with Id {noteId} not found or does not belong to you.");

        return true;
    }

    // ── Day-15 Operations ─────────────────────────────────────────────────────

    /// <summary>Toggles Pin on a note. Pinned notes appear first in list.</summary>
    public async Task<NoteResponseDto> TogglePinAsync(int noteId, int userId)
    {
        var note = await _noteRepository.TogglePinAsync(noteId, userId);
        if (note == null)
            throw new KeyNotFoundException($"Note with Id {noteId} not found or does not belong to you.");

        return ToResponseDto(note, note.User?.Email ?? string.Empty);
    }

    /// <summary>Toggles Archive on a note. Archived notes are hidden from main view.</summary>
    public async Task<NoteResponseDto> ToggleArchiveAsync(int noteId, int userId)
    {
        var note = await _noteRepository.ToggleArchiveAsync(noteId, userId);
        if (note == null)
            throw new KeyNotFoundException($"Note with Id {noteId} not found or does not belong to you.");

        return ToResponseDto(note, note.User?.Email ?? string.Empty);
    }

    /// <summary>
    /// Toggles Trash (soft-delete) on a note.
    /// Trashed notes are not permanently deleted — they can be restored.
    /// </summary>
    public async Task<NoteResponseDto> ToggleTrashAsync(int noteId, int userId)
    {
        var note = await _noteRepository.ToggleTrashAsync(noteId, userId);
        if (note == null)
            throw new KeyNotFoundException($"Note with Id {noteId} not found or does not belong to you.");

        return ToResponseDto(note, note.User?.Email ?? string.Empty);
    }

    /// <summary>
    /// Searches notes by title/description.
    /// E.g. query="a" returns all notes where title or description contains "a".
    /// </summary>
    public async Task<List<NoteResponseDto>> SearchNotesAsync(int userId, string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            throw new ArgumentException("Search query cannot be empty.");

        var notes = await _noteRepository.SearchNotesAsync(userId, query);
        return notes.Select(n => ToResponseDto(n, n.User?.Email ?? string.Empty)).ToList();
    }

    private static NoteResponseDto ToResponseDto(Note n, string userEmail) => new()
    {
        Id          = n.Id,
        Title       = n.Title,
        Description = n.Description,
        UserId      = n.UserId,
        UserEmail   = userEmail,
        IsPinned    = n.IsPinned,
        IsArchived  = n.IsArchived,
        IsTrashed   = n.IsTrashed,
        CreatedAt   = n.CreatedAt,
        UpdatedAt   = n.UpdatedAt
    };
}
