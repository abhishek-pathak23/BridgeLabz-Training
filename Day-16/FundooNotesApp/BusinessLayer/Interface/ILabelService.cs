using ModelLayer;

namespace BusinessLayer.Interface;

/// <summary>
/// Day-16: Labels service contract.
/// Validates ownership, maps entities → DTOs, and coordinates with ILabelRepository.
/// </summary>
public interface ILabelService
{
    // ── Label CRUD ────────────────────────────────────────────────────────────
    Task<LabelResponseDto>       CreateLabelAsync(CreateLabelDto dto, int userId);
    Task<List<LabelResponseDto>> GetAllLabelsAsync(int userId);
    Task<LabelResponseDto>       GetLabelByIdAsync(int labelId, int userId);
    Task<LabelResponseDto>       UpdateLabelAsync(int labelId, UpdateLabelDto dto, int userId);
    Task<bool>                   DeleteLabelAsync(int labelId, int userId);

    // ── Note Assignment ───────────────────────────────────────────────────────
    Task<bool>                   AssignLabelToNoteAsync(int noteId, int labelId, int userId);
    Task<bool>                   RemoveLabelFromNoteAsync(int noteId, int labelId, int userId);
    Task<List<NoteResponseDto>>  GetNotesByLabelAsync(int labelId, int userId);
}
