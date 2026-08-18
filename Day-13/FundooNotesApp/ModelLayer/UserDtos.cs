using System.ComponentModel.DataAnnotations;

namespace ModelLayer;

public record UserRegisterDto
{
    [Required(ErrorMessage = "First Name is required.")]
    [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
    public string FirstName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
    public string LastName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string Password { get; init; } = string.Empty;

    /// <summary>
    /// Optional role for assignment: "User" or "Admin". Defaults to "User".
    /// </summary>
    [RegularExpression("^(User|Admin)$", ErrorMessage = "Role must be either 'User' or 'Admin'.")]
    public string Role { get; init; } = "User";
}

public record UserLoginDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; init; } = string.Empty;
}

public record AuthResponseDto
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public string AuthScheme { get; init; } = "GroundworkBearer";
    public string GroundworkToken { get; init; } = string.Empty;
    public UserResponseDto? User { get; init; }
}

public record ForgotPasswordDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    public string Email { get; init; } = string.Empty;
}

public record ResetPasswordDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "Reset Token is required.")]
    public string Token { get; init; } = string.Empty;

    [Required(ErrorMessage = "New Password is required.")]
    [MinLength(6, ErrorMessage = "New Password must be at least 6 characters long.")]
    public string NewPassword { get; init; } = string.Empty;
}

public record UpdateUserDto
{
    [Required(ErrorMessage = "First Name is required.")]
    [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
    public string FirstName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
    public string LastName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    public string Email { get; init; } = string.Empty;

    [RegularExpression("^(User|Admin)$", ErrorMessage = "Role must be either 'User' or 'Admin'.")]
    public string? Role { get; init; }
}

public record PatchEmailDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    public string Email { get; init; } = string.Empty;
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

public record ClaimsDebugDto
{
    public string Subject { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
    public bool IsAuthenticated { get; init; }
    public string AuthenticationType { get; init; } = string.Empty;
    public Dictionary<string, string> Claims { get; init; } = new();
}
