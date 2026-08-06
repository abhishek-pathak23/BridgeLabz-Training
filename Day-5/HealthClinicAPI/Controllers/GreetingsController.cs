using Microsoft.AspNetCore.Mvc;
using HealthClinicAPI.Models;

namespace HealthClinicAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GreetingsController : ControllerBase
{
    private static readonly List<GreetingItem> Greetings = new()
    {
        new GreetingItem { Id = 1, Message = "Welcome to ASP.NET Core Web API!", Sender = "BridgeLabz Admin", CreatedAt = DateTime.UtcNow },
        new GreetingItem { Id = 2, Message = "Hello! ASP.NET Core makes RESTful APIs simple and powerful.", Sender = "Instructor", CreatedAt = DateTime.UtcNow }
    };

    // GET: api/greetings
    [HttpGet]
    public ActionResult<IEnumerable<GreetingItem>> GetAllGreetings()
    {
        return Ok(Greetings);
    }

    // GET: api/greetings/1
    [HttpGet("{id:int}")]
    public ActionResult<GreetingItem> GetGreetingById(int id)
    {
        var greeting = Greetings.FirstOrDefault(g => g.Id == id);
        if (greeting == null)
        {
            return NotFound(new { Message = $"Greeting with ID {id} was not found." });
        }
        return Ok(greeting);
    }

    // POST: api/greetings
    [HttpPost]
    public ActionResult<GreetingItem> CreateGreeting([FromBody] GreetingItem newGreeting)
    {
        if (string.IsNullOrWhiteSpace(newGreeting.Message))
        {
            return BadRequest(new { Message = "Message content cannot be empty." });
        }

        newGreeting.Id = Greetings.Count > 0 ? Greetings.Max(g => g.Id) + 1 : 1;
        newGreeting.CreatedAt = DateTime.UtcNow;
        Greetings.Add(newGreeting);

        return CreatedAtAction(nameof(GetGreetingById), new { id = newGreeting.Id }, newGreeting);
    }

    // PUT: api/greetings/1
    [HttpPut("{id:int}")]
    public IActionResult UpdateGreeting(int id, [FromBody] GreetingItem updatedGreeting)
    {
        var existing = Greetings.FirstOrDefault(g => g.Id == id);
        if (existing == null)
        {
            return NotFound(new { Message = $"Greeting with ID {id} was not found." });
        }

        if (string.IsNullOrWhiteSpace(updatedGreeting.Message))
        {
            return BadRequest(new { Message = "Message content cannot be empty." });
        }

        existing.Message = updatedGreeting.Message;
        existing.Sender = string.IsNullOrWhiteSpace(updatedGreeting.Sender) ? existing.Sender : updatedGreeting.Sender;

        return Ok(existing);
    }

    // DELETE: api/greetings/1
    [HttpDelete("{id:int}")]
    public IActionResult DeleteGreeting(int id)
    {
        var existing = Greetings.FirstOrDefault(g => g.Id == id);
        if (existing == null)
        {
            return NotFound(new { Message = $"Greeting with ID {id} was not found." });
        }

        Greetings.Remove(existing);
        return NoContent();
    }
}
