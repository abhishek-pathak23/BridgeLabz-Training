using BusinessLayer.Interface;
using ModelLayer;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service;

public class EmployeeBL : IEmployeeBL
{
    private readonly IEmployeeRL _employeeRL;

    public EmployeeBL(IEmployeeRL employeeRL)
    {
        _employeeRL = employeeRL;
    }

    public async Task<List<Employee>> GetAllEmployeesAsync(string? department = null, string? search = null)
    {
        return await _employeeRL.GetAllEmployeesAsync(department, search);
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _employeeRL.GetEmployeeByIdAsync(id);
    }

    public async Task<Employee> AddEmployeeAsync(CreateEmployeeDto dto)
    {
        if (dto.Salary < 0)
        {
            throw new ArgumentException("Salary cannot be negative.");
        }

        var employee = new Employee
        {
            Name = dto.Name.Trim(),
            Department = string.IsNullOrWhiteSpace(dto.Department) ? "General" : dto.Department.Trim(),
            Salary = dto.Salary,
            Email = dto.Email.Trim().ToLower(),
            CreatedAt = DateTime.UtcNow
        };

        return await _employeeRL.AddEmployeeAsync(employee);
    }

    public async Task<Employee?> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
    {
        if (dto.Salary < 0)
        {
            throw new ArgumentException("Salary cannot be negative.");
        }

        var employee = new Employee
        {
            Id = id,
            Name = dto.Name.Trim(),
            Department = string.IsNullOrWhiteSpace(dto.Department) ? "General" : dto.Department.Trim(),
            Salary = dto.Salary,
            Email = dto.Email.Trim().ToLower()
        };

        return await _employeeRL.UpdateEmployeeAsync(id, employee);
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        return await _employeeRL.DeleteEmployeeAsync(id);
    }
}
