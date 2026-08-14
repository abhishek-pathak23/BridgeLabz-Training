using ModelLayer;

namespace RepositoryLayer.Interface;

public interface IEmployeeRL
{
    Task<List<Employee>> GetAllEmployeesAsync(string? department = null, string? search = null);
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task<Employee> AddEmployeeAsync(Employee employee);
    Task<Employee?> UpdateEmployeeAsync(int id, Employee employee);
    Task<bool> DeleteEmployeeAsync(int id);
}
