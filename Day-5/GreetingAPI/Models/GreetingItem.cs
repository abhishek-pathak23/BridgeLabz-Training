namespace GreetingAPI.Models;

public class GreetingItem
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Sender { get; set; } = "System";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
