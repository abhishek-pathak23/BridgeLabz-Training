using Microsoft.AspNetCore.Mvc;
using GreetingsApp.Models;

namespace GreetingsApp.Controllers;

public class HomeController : Controller
{
    // GET: /
    [HttpGet]
    public IActionResult Index()
    {
        var model = new GreetingModel
        {
            Message = "Hello World! Welcome to My Greetings App."
        };
        return View(model);
    }

    // POST: /
    [HttpPost]
    public IActionResult Index(string? userName)
    {
        string greetingText = string.IsNullOrWhiteSpace(userName)
            ? "Hello World! Welcome to My Greetings App."
            : $"Hello, {userName.Trim()}! Welcome to My Greetings App.";

        var model = new GreetingModel
        {
            UserInputName = userName,
            Message = greetingText
        };

        return View(model);
    }
}
