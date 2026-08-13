using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace EmployeePayrollApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeBL _employeeBL;

    public EmployeeController(IEmployeeBL employeeBL)
    {
        _employeeBL = employeeBL;
    }

    /// <summary>
    /// GET /api/Employee - Get all employees with optional department or search filter
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? department, [FromQuery] string? search)
    {
        var employees = await _employeeBL.GetAllEmployeesAsync(department, search);
        return Ok(employees);
    }

    /// <summary>
    /// GET /api/Employee/{id} - Get employee by ID
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _employeeBL.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return NotFound(new { Message = $"Employee with ID {id} was not found." });
        }
        return Ok(employee);
    }

    /// <summary>
    /// POST /api/Employee - Create new employee
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
    {
        try
        {
            var created = await _employeeBL.AddEmployeeAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    /// <summary>
    /// PUT /api/Employee/{id} - Update existing employee
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto dto)
    {
        try
        {
            var updated = await _employeeBL.UpdateEmployeeAsync(id, dto);
            if (updated == null)
            {
                return NotFound(new { Message = $"Employee with ID {id} was not found." });
            }
            return Ok(updated);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    /// <summary>
    /// DELETE /api/Employee/{id} - Delete employee by ID
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _employeeBL.DeleteEmployeeAsync(id);
        if (!result)
        {
            return NotFound(new { Message = $"Employee with ID {id} was not found." });
        }
        return Ok(new { Message = $"Employee with ID {id} was successfully deleted." });
    }
}
