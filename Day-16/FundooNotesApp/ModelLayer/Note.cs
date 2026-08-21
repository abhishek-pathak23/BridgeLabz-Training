using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer;

/// <summary>
/// Note entity — belongs to a specific User (identified by JWT claims).
/// Day-15: Extended with Pin / Archive / Trash (soft-delete) support.
/// Day-16: Extended with Labels (many-to-many via NoteLabel join table).
/// </summary>
[Table("Notes")]
public class Note
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(5000, ErrorMessage = "Description cannot exceed 5000 characters.")]
    public string? Description { get; set; }

    /// <summary>FK to the User who owns this note (from JWT 'sub' claim).</summary>
    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    // ── Day-15 Feature Fields ────────────────────────────────────────────────

    /// <summary>Pinned notes appear at the top of the list.</summary>
    public bool IsPinned { get; set; } = false;

    /// <summary>Archived notes are hidden from the main view.</summary>
    public bool IsArchived { get; set; } = false;

    /// <summary>Trashed notes are soft-deleted (not permanently removed).</summary>
    public bool IsTrashed { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // ── Day-16: Labels (many-to-many) ────────────────────────────────────────
    /// <summary>Labels assigned to this note via the NoteLabel join table.</summary>
    public ICollection<NoteLabel> NoteLabels { get; set; } = new List<NoteLabel>();
}
