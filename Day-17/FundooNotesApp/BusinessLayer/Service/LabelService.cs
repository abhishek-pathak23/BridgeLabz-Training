using BusinessLayer.Interface;
using Microsoft.Extensions.Logging;
using ModelLayer;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service;

/// <summary>
/// Day-16: LabelService — business logic for Tags/Labels management.
/// Validates ownership, maps entities → DTOs, and delegates persistence to ILabelRepository.
/// NLog is injected here for structured logging.
/// </summary>
public class LabelService : ILabelService
{
    private readonly ILabelRepository _labelRepository;
    private readonly ILogger<LabelService> _logger;

    public LabelService(ILabelRepository labelRepository, ILogger<LabelService> logger)
    {
        _labelRepository = labelRepository;
        _logger          = logger;
    }

    // ── Label CRUD ────────────────────────────────────────────────────────────

    /// <summary>Creates a new label for the authenticated user.</summary>
    public async Task<LabelResponseDto> CreateLabelAsync(CreateLabelDto dto, int userId)
    {
        _logger.LogInformation("CreateLabel: UserId={UserId}, Name={Name}", userId, dto.Name);

        var label = new Label
        {
            Name   = dto.Name.Trim(),
            Color  = dto.Color.Trim(),
            UserId = userId
        };

        var created = await _labelRepository.CreateLabelAsync(label);
        _logger.LogInformation("Label created: Id={Id}", created.Id);
        return ToResponseDto(created);
    }

    /// <summary>Gets all labels belonging to the authenticated user.</summary>
    public async Task<List<LabelResponseDto>> GetAllLabelsAsync(int userId)
    {
        _logger.LogInformation("GetAllLabels: UserId={UserId}", userId);
        var labels = await _labelRepository.GetAllLabelsByUserAsync(userId);
        return labels.Select(ToResponseDto).ToList();
    }

    /// <summary>Gets a single label by Id — validates ownership.</summary>
    public async Task<LabelResponseDto> GetLabelByIdAsync(int labelId, int userId)
    {
        var label = await _labelRepository.GetLabelByIdAsync(labelId);
        if (label == null || label.UserId != userId)
            throw new KeyNotFoundException($"Label with Id {labelId} not found or does not belong to you.");

        return ToResponseDto(label);
    }

    /// <summary>Updates an existing label — validates ownership.</summary>
    public async Task<LabelResponseDto> UpdateLabelAsync(int labelId, UpdateLabelDto dto, int userId)
    {
        _logger.LogInformation("UpdateLabel: LabelId={LabelId}, UserId={UserId}", labelId, userId);

        var label = await _labelRepository.GetLabelByIdAsync(labelId);
        if (label == null || label.UserId != userId)
            throw new KeyNotFoundException($"Label with Id {labelId} not found or does not belong to you.");

        label.Name  = dto.Name.Trim();
        label.Color = dto.Color.Trim();

        var updated = await _labelRepository.UpdateLabelAsync(label);
        return ToResponseDto(updated);
    }

    /// <summary>Deletes a label — validates ownership. Cascades NoteLabel rows.</summary>
    public async Task<bool> DeleteLabelAsync(int labelId, int userId)
    {
        _logger.LogInformation("DeleteLabel: LabelId={LabelId}, UserId={UserId}", labelId, userId);

        var deleted = await _labelRepository.DeleteLabelAsync(labelId, userId);
        if (!deleted)
            throw new KeyNotFoundException($"Label with Id {labelId} not found or does not belong to you.");

        return true;
    }

    // ── Note Assignment ───────────────────────────────────────────────────────

    /// <summary>Assigns a label to a note — validates both belong to the user.</summary>
    public async Task<bool> AssignLabelToNoteAsync(int noteId, int labelId, int userId)
    {
        _logger.LogInformation("AssignLabel: NoteId={NoteId}, LabelId={LabelId}, UserId={UserId}", noteId, labelId, userId);

        var result = await _labelRepository.AssignLabelToNoteAsync(noteId, labelId, userId);
        if (!result)
            throw new KeyNotFoundException($"Note (Id:{noteId}) or Label (Id:{labelId}) not found or does not belong to you.");

        return true;
    }

    /// <summary>Removes a label from a note — validates both belong to the user.</summary>
    public async Task<bool> RemoveLabelFromNoteAsync(int noteId, int labelId, int userId)
    {
        _logger.LogInformation("RemoveLabel: NoteId={NoteId}, LabelId={LabelId}, UserId={UserId}", noteId, labelId, userId);

        var result = await _labelRepository.RemoveLabelFromNoteAsync(noteId, labelId, userId);
        if (!result)
            throw new KeyNotFoundException($"Note (Id:{noteId}) or Label (Id:{labelId}) not found or not assigned.");

        return true;
    }

    /// <summary>Returns all notes tagged with the specified label for the user.</summary>
    public async Task<List<NoteResponseDto>> GetNotesByLabelAsync(int labelId, int userId)
    {
        // Validate label ownership
        var label = await _labelRepository.GetLabelByIdAsync(labelId);
        if (label == null || label.UserId != userId)
            throw new KeyNotFoundException($"Label with Id {labelId} not found or does not belong to you.");

        var notes = await _labelRepository.GetNotesByLabelAsync(labelId, userId);
        return notes.Select(n => ToNoteResponseDto(n)).ToList();
    }

    // ── Mappers ───────────────────────────────────────────────────────────────

    private static LabelResponseDto ToResponseDto(Label l) => new()
    {
        Id        = l.Id,
        Name      = l.Name,
        Color     = l.Color,
        UserId    = l.UserId,
        CreatedAt = l.CreatedAt,
        UpdatedAt = l.UpdatedAt
    };

    private static NoteResponseDto ToNoteResponseDto(Note n) => new()
    {
        Id          = n.Id,
        Title       = n.Title,
        Description = n.Description,
        UserId      = n.UserId,
        UserEmail   = n.User?.Email ?? string.Empty,
        IsPinned    = n.IsPinned,
        IsArchived  = n.IsArchived,
        IsTrashed   = n.IsTrashed,
        CreatedAt   = n.CreatedAt,
        UpdatedAt   = n.UpdatedAt,
        Labels      = n.NoteLabels
                       .Where(nl => nl.Label != null)
                       .Select(nl => ToResponseDto(nl.Label!))
                       .ToList()
    };
}
