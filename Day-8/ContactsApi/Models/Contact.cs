using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Models;

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Category { get; set; } = "Personal";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public record CreateContactDto(
    [Required, StringLength(50, MinimumLength = 2)] string FirstName,
    [Required, StringLength(50, MinimumLength = 2)] string LastName,
    [Required, EmailAddress] string Email,
    [Required, Phone] string PhoneNumber,
    [StringLength(30)] string Category = "Personal"
);

public record UpdateContactDto(
    [Required, StringLength(50, MinimumLength = 2)] string FirstName,
    [Required, StringLength(50, MinimumLength = 2)] string LastName,
    [Required, EmailAddress] string Email,
    [Required, Phone] string PhoneNumber,
    [StringLength(30)] string Category = "Personal"
);
