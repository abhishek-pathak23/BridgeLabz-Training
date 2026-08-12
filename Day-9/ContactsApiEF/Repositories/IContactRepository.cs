using ContactsApi.Models;

namespace ContactsApi.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync(string? search = null, string? category = null);
    Task<Contact?> GetByIdAsync(int id);
    Task<Contact> CreateAsync(Contact contact);
    Task<Contact?> UpdateAsync(Contact contact);
    Task<bool> DeleteAsync(int id);
}
