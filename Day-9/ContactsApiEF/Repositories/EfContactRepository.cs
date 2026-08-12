using ContactsApi.Data;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Repositories;

public class EfContactRepository : IContactRepository
{
    private readonly ContactsDbContext _context;

    // Dependency Injection: The DbContext is injected into the repository
    public EfContactRepository(ContactsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync(string? search = null, string? category = null)
    {
        // AsQueryable allows us to dynamically build our SQL query before sending it to the database
        var query = _context.Contacts.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c => c.FirstName.Contains(search) || 
                                     c.LastName.Contains(search) || 
                                     c.Email.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(c => c.Category.Equals(category));
        }

        // ToListAsync() executes the final dynamically built query against the database
        return await query.ToListAsync();
    }

    public async Task<Contact?> GetByIdAsync(int id)
    {
        // FindAsync is highly optimized for retrieving an entity by its Primary Key
        return await _context.Contacts.FindAsync(id);
    }

    public async Task<Contact> CreateAsync(Contact contact)
    {
        // EF Core begins tracking the new contact entity
        _context.Contacts.Add(contact);
        
        // SaveChangesAsync commits the new record to the database
        await _context.SaveChangesAsync();
        
        return contact;
    }

    public async Task<Contact?> UpdateAsync(Contact contact)
    {
        // First, fetch the existing record so EF Core can track it
        var existingContact = await _context.Contacts.FindAsync(contact.Id);
        if (existingContact == null)
            return null;

        // Update properties on the tracked entity

        existingContact.FirstName = contact.FirstName;
        existingContact.LastName = contact.LastName;
        existingContact.Email = contact.Email;
        existingContact.PhoneNumber = contact.PhoneNumber;
        existingContact.Category = contact.Category;

        // EF Core automatically detects which properties were changed and generates an UPDATE query
        await _context.SaveChangesAsync();
        return existingContact;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null)
            return false;

        // Mark the entity for deletion
        _context.Contacts.Remove(contact);
        
        // Execute the DELETE query
        await _context.SaveChangesAsync();
        return true;
    }
}
