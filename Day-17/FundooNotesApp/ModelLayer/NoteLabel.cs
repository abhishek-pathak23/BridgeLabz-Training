using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer;

/// <summary>
/// NoteLabel — join table for the many-to-many relationship between Notes and Labels.
/// Day-16: A Note can have multiple Labels; a Label can be on multiple Notes.
/// </summary>
[Table("NoteLabels")]
public class NoteLabel
{
    /// <summary>FK to the Note.</summary>
    [Required]
    public int NoteId { get; set; }

    [ForeignKey(nameof(NoteId))]
    public Note? Note { get; set; }

    /// <summary>FK to the Label.</summary>
    [Required]
    public int LabelId { get; set; }

    [ForeignKey(nameof(LabelId))]
    public Label? Label { get; set; }
}
