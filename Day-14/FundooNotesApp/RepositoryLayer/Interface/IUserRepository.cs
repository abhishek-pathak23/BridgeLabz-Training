using ModelLayer;

namespace RepositoryLayer.Interface;

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(int id);
    Task<bool> UserExistsAsync(string email);
}
