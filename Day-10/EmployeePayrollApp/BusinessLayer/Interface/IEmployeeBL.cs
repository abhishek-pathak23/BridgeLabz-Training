using ModelLayer;

namespace BusinessLayer.Interface;

public interface IEmployeeBL
{
    Task<List<Employee>> GetAllEmployeesAsync(string? department = null, string? search = null);
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task<Employee> AddEmployeeAsync(CreateEmployeeDto dto);
    Task<Employee?> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto);
    Task<bool> DeleteEmployeeAsync(int id);
}
