using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer;

/// <summary>
/// Label (Tag) entity — belongs to a specific User.
/// Day-16: Labels can be assigned to multiple Notes (many-to-many via NoteLabel join table).
/// </summary>
[Table("Labels")]
public class Label
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>Label name — must be unique per user (e.g. "Work", "Personal").</summary>
    [Required(ErrorMessage = "Label name is required.")]
    [StringLength(50, ErrorMessage = "Label name cannot exceed 50 characters.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>Optional hex color for the label badge (e.g. "#FF5733").</summary>
    [StringLength(7, ErrorMessage = "Color must be a valid hex code (e.g. #FF5733).")]
    public string Color { get; set; } = "#FFFFFF";

    /// <summary>FK to the User who owns this label (from JWT 'sub' claim).</summary>
    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation: many-to-many with Notes via NoteLabel join table
    public ICollection<NoteLabel> NoteLabels { get; set; } = new List<NoteLabel>();
}
