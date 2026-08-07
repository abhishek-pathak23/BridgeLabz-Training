using Microsoft.AspNetCore.Mvc;

namespace GreetingsApp.Controllers;

[ApiController]
[Route("api/greetings")]
public class GreetingsApiController : ControllerBase
{
    // GET: /api/greetings?name=Steve
    [HttpGet]
    public IActionResult GetGreeting([FromQuery] string? name)
    {
        string text = string.IsNullOrWhiteSpace(name)
            ? "Hello World! Welcome to My Greetings App."
            : $"Hello, {name.Trim()}! Welcome to My Greetings App.";

        return Ok(new { message = text });
    }
}
