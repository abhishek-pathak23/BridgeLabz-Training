using System.ComponentModel.DataAnnotations;

namespace ModelLayer;

// ─── User Registration / Login DTOs ──────────────────────────────────────────

public record UserRegisterDto
{
    [Required(ErrorMessage = "First Name is required.")]
    [StringLength(50)]
    public string FirstName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(50)]
    public string LastName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; init; } = string.Empty;

    [RegularExpression("^(User|Admin)$", ErrorMessage = "Role must be 'User' or 'Admin'.")]
    public string Role { get; init; } = "User";
}

public record UserLoginDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; init; } = string.Empty;
}

public record ForgotPasswordDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress]
    public string Email { get; init; } = string.Empty;
}

public record ResetPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; init; } = string.Empty;

    [Required]
    public string Token { get; init; } = string.Empty;

    [Required]
    [MinLength(6)]
    public string NewPassword { get; init; } = string.Empty;
}

// ─── Response DTOs ────────────────────────────────────────────────────────────

public record UpdateProfileDto
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; init; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; init; } = string.Empty;
}

public record UserResponseDto
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Role { get; init; } = "User";
    public DateTime CreatedAt { get; init; }
}

public record AuthResponseDto
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public string AuthScheme { get; init; } = "Bearer";

    /// <summary>JWT Token containing UserId + Email claims — paste into jwt.io to debug.</summary>
    public string Token { get; init; } = string.Empty;

    public UserResponseDto? User { get; init; }
}

// ─── JWT Debugger DTO ─────────────────────────────────────────────────────────

/// <summary>
/// Day-14: JWT Debugger — shows the decoded JWT claims (Header, Payload, Signature info).
/// Paste the returned Token into https://jwt.io to visualise the same data.
/// </summary>
public record JwtDebugDto
{
    /// <summary>Decoded JWT Header (algorithm, type).</summary>
    public object Header { get; init; } = new { };

    /// <summary>Decoded JWT Payload — includes UserId (sub), Email, Role, etc.</summary>
    public object Payload { get; init; } = new { };

    /// <summary>Human-readable hint to use jwt.io.</summary>
    public string Hint { get; init; } = "Paste the Token into https://jwt.io to inspect Header, Payload & Signature.";

    /// <summary>All resolved claims from HttpContext.User (from ASP.NET JWT middleware).</summary>
    public Dictionary<string, string> ResolvedClaims { get; init; } = new();

    public int? UserId { get; init; }
    public string? Email { get; init; }
    public string? Role { get; init; }
    public bool IsAuthenticated { get; init; }
}

// ─── Notes DTOs ───────────────────────────────────────────────────────────────

public record CreateNoteDto
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200)]
    public string Title { get; init; } = string.Empty;

    [StringLength(5000)]
    public string? Description { get; init; }

    public DateTime? Reminder { get; init; }
}

public record UpdateNoteDto
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200)]
    public string Title { get; init; } = string.Empty;

    [StringLength(5000)]
    public string? Description { get; init; }

    public DateTime? Reminder { get; init; }
}

public record NoteResponseDto
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }

    /// <summary>Extracted from JWT claim 'sub' (UserId).</summary>
    public int UserId { get; init; }

    /// <summary>Extracted from JWT claim 'email'.</summary>
    public string UserEmail { get; init; } = string.Empty;

    // ── Day-15 Status Fields ──────────────────────────────────────────────────
    public bool IsPinned { get; init; }
    public bool IsArchived { get; init; }
    public bool IsTrashed { get; init; }

    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

    // ── Day-17: Reminder ──────────────────────────────────────────────────────
    public DateTime? Reminder { get; init; }

    // ── Day-16: Labels ────────────────────────────────────────────────────────
    /// <summary>Labels assigned to this note.</summary>
    public List<LabelResponseDto> Labels { get; init; } = new();
}

// ─── Labels / Tags DTOs ───────────────────────────────────────────────────────

/// <summary>Day-16: Create a new label (tag).</summary>
public record CreateLabelDto
{
    [Required(ErrorMessage = "Label name is required.")]
    [StringLength(50, ErrorMessage = "Label name cannot exceed 50 characters.")]
    public string Name { get; init; } = string.Empty;

    /// <summary>Optional hex color code (e.g. #FF5733). Defaults to #FFFFFF.</summary>
    [StringLength(7)]
    [RegularExpression("^#[0-9A-Fa-f]{6}$", ErrorMessage = "Color must be a valid hex code like #FF5733.")]
    public string Color { get; init; } = "#FFFFFF";
}

/// <summary>Day-16: Update an existing label.</summary>
public record UpdateLabelDto
{
    [Required(ErrorMessage = "Label name is required.")]
    [StringLength(50)]
    public string Name { get; init; } = string.Empty;

    [StringLength(7)]
    [RegularExpression("^#[0-9A-Fa-f]{6}$", ErrorMessage = "Color must be a valid hex code like #FF5733.")]
    public string Color { get; init; } = "#FFFFFF";
}

/// <summary>Day-16: Response DTO for a label.</summary>
public record LabelResponseDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Color { get; init; } = "#FFFFFF";
    public int UserId { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
