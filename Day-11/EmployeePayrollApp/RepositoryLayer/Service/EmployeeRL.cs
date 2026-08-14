using Microsoft.EntityFrameworkCore;
using ModelLayer;
using ModelLayer.Context;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service;

public class EmployeeRL : IEmployeeRL
{
    private readonly EmployeeDbContext _context;

    public EmployeeRL(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllEmployeesAsync(string? department = null, string? search = null)
    {
        IQueryable<Employee> query = _context.Employees.AsQueryable();

        if (!string.IsNullOrWhiteSpace(department))
        {
            query = query.Where(e => e.Department.ToLower() == department.ToLower());
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(e => e.Name.Contains(search) || e.Email.Contains(search));
        }

        return await query.OrderBy(e => e.Id).ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> UpdateEmployeeAsync(int id, Employee employee)
    {
        var existing = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        if (existing == null)
            return null;

        existing.Name = employee.Name;
        existing.Department = employee.Department;
        existing.Salary = employee.Salary;
        existing.Email = employee.Email;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        if (employee == null)
            return false;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }
}
