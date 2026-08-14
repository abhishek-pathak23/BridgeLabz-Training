using System.ComponentModel.DataAnnotations;

namespace ModelLayer;

public record CreateEmployeeDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; init; } = string.Empty;

    [Required(ErrorMessage = "Department is required.")]
    [StringLength(50, ErrorMessage = "Department cannot exceed 50 characters.")]
    public string Department { get; init; } = "General";

    [Range(0, 10000000, ErrorMessage = "Salary must be a non-negative value.")]
    public decimal Salary { get; init; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; init; } = string.Empty;
}

public record UpdateEmployeeDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; init; } = string.Empty;

    [Required(ErrorMessage = "Department is required.")]
    [StringLength(50, ErrorMessage = "Department cannot exceed 50 characters.")]
    public string Department { get; init; } = "General";

    [Range(0, 10000000, ErrorMessage = "Salary must be a non-negative value.")]
    public decimal Salary { get; init; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; init; } = string.Empty;
}
