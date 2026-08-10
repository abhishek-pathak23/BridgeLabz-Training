using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Models;

// Domain Model
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

// Data Transfer Objects (DTOs)
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

// In-Memory Repository Service
public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllAsync(string? search = null, string? category = null);
    Task<Contact?> GetByIdAsync(int id);
    Task<Contact> CreateAsync(CreateContactDto dto);
    Task<Contact?> UpdateAsync(int id, UpdateContactDto dto);
    Task<bool> DeleteAsync(int id);
}

public class ContactService : IContactService
{
    private readonly ConcurrentDictionary<int, Contact> _contacts = new();
    private int _nextId = 1;

    public ContactService()
    {
        SeedInitialData();
    }

    private void SeedInitialData()
    {
        var sampleContacts = new[]
        {
            new Contact { Id = _nextId++, FirstName = "Abhishek", LastName = "Pathak", Email = "abhishek.pathak@bridgelabz.com", PhoneNumber = "+91-9876543210", Category = "Work", CreatedAt = DateTime.UtcNow.AddDays(-10) },
            new Contact { Id = _nextId++, FirstName = "Ananya", LastName = "Sharma", Email = "ananya.sharma@example.com", PhoneNumber = "+91-9123456789", Category = "Personal", CreatedAt = DateTime.UtcNow.AddDays(-5) },
            new Contact { Id = _nextId++, FirstName = "Rahul", LastName = "Verma", Email = "rahul.verma@techcorp.io", PhoneNumber = "+91-9988776655", Category = "Work", CreatedAt = DateTime.UtcNow.AddDays(-2) },
            new Contact { Id = _nextId++, FirstName = "Priya", LastName = "Patel", Email = "priya.patel@family.org", PhoneNumber = "+91-9554433221", Category = "Family", CreatedAt = DateTime.UtcNow.AddDays(-1) }
        };

        foreach (var contact in sampleContacts)
        {
            _contacts[contact.Id] = contact;
        }
    }

    public Task<IEnumerable<Contact>> GetAllAsync(string? search = null, string? category = null)
    {
        IEnumerable<Contact> result = _contacts.Values;

        if (!string.IsNullOrWhiteSpace(search))
        {
            var query = search.Trim().ToLowerInvariant();
            result = result.Where(c => 
                c.FirstName.ToLowerInvariant().Contains(query) ||
                c.LastName.ToLowerInvariant().Contains(query) ||
                c.Email.ToLowerInvariant().Contains(query) ||
                c.PhoneNumber.Contains(query));
        }

        if (!string.IsNullOrWhiteSpace(category) && !category.Equals("All", StringComparison.OrdinalIgnoreCase))
        {
            result = result.Where(c => c.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(result.OrderByDescending(c => c.Id).AsEnumerable());
    }

    public Task<Contact?> GetByIdAsync(int id)
    {
        _contacts.TryGetValue(id, out var contact);
        return Task.FromResult(contact);
    }

    public Task<Contact> CreateAsync(CreateContactDto dto)
    {
        var id = Interlocked.Increment(ref _nextId) - 1;
        var contact = new Contact
        {
            Id = id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Category = string.IsNullOrWhiteSpace(dto.Category) ? "Personal" : dto.Category,
            CreatedAt = DateTime.UtcNow
        };

        _contacts[id] = contact;
        return Task.FromResult(contact);
    }

    public Task<Contact?> UpdateAsync(int id, UpdateContactDto dto)
    {
        if (!_contacts.TryGetValue(id, out var existing))
        {
            return Task.FromResult<Contact?>(null);
        }

        existing.FirstName = dto.FirstName;
        existing.LastName = dto.LastName;
        existing.Email = dto.Email;
        existing.PhoneNumber = dto.PhoneNumber;
        existing.Category = string.IsNullOrWhiteSpace(dto.Category) ? "Personal" : dto.Category;

        _contacts[id] = existing;
        return Task.FromResult<Contact?>(existing);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var removed = _contacts.TryRemove(id, out _);
        return Task.FromResult(removed);
    }
}
