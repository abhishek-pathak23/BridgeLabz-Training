using Microsoft.AspNetCore.Mvc;

namespace FundooNotesApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoutingDemoController : ControllerBase
{
    /// <summary>
    /// GET /api/RoutingDemo/product/{id:int:min(1)} - Route constraint ensuring integer >= 1
    /// </summary>
    [HttpGet("product/{id:int:min(1)}")]
    public IActionResult GetProductById(int id)
    {
        return Ok(new
        {
            Constraint = "int:min(1)",
            PassedId = id,
            Message = $"Valid product ID {id} matching constraint 'int:min(1)'."
        });
    }

    /// <summary>
    /// GET /api/RoutingDemo/by-code/{code} - Route with regex constraint validating product code format (e.g. ABC-123)
    /// </summary>
    [HttpGet(@"by-code/{code:regex(^[[A-Z]]{{3}}-[[0-9]]{{3}}$)}")]
    public IActionResult GetByCodeRegex(string code)
    {
        return Ok(new
        {
            Constraint = @"regex(^[A-Z]{3}-[0-9]{3}$)",
            PassedCode = code,
            Message = $"Code '{code}' successfully matched the route regex constraint."
        });
    }

    /// <summary>
    /// GET /api/RoutingDemo/role-filter/{role?} - Route with optional parameter and default fallback
    /// </summary>
    [HttpGet("role-filter/{role?}")]
    public IActionResult FilterByRole(string? role = "All")
    {
        return Ok(new
        {
            Constraint = "Optional parameter {role?}",
            ResolvedRole = role ?? "All",
            Message = $"Route resolved with role '{role ?? "All"}' (fallback to 'All' when omitted)."
        });
    }

    /// <summary>
    /// GET /api/RoutingDemo/range/{page:int:range(1,100)} - Route constraint with range restriction
    /// </summary>
    [HttpGet("range/{page:int:range(1,100)}")]
    public IActionResult GetByPageRange(int page)
    {
        return Ok(new
        {
            Constraint = "int:range(1,100)",
            Page = page,
            Message = $"Page {page} within valid range 1 to 100."
        });
    }

    /// <summary>
    /// GET /api/RoutingDemo/audit/{date:datetime} - Route with datetime constraint
    /// </summary>
    [HttpGet("audit/{date:datetime}")]
    public IActionResult GetAuditByDate(DateTime date)
    {
        return Ok(new
        {
            Constraint = "datetime",
            ResolvedDate = date.ToString("yyyy-MM-dd HH:mm:ss"),
            Message = $"Successfully parsed valid datetime from route: {date:yyyy-MM-dd}."
        });
    }
}
