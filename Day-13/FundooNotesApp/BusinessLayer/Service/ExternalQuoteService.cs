using System.Text.Json;
using BusinessLayer.Interface;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Service;

public class ExternalQuoteService : IExternalQuoteService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ExternalQuoteService> _logger;

    public ExternalQuoteService(HttpClient httpClient, ILogger<ExternalQuoteService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _httpClient.BaseAddress = new Uri("https://dummyjson.com/");
        _httpClient.Timeout = TimeSpan.FromSeconds(5);
    }

    public async Task<ExternalQuoteDto> GetDailyInspirationalQuoteAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("quotes/random");
            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                using var jsonDoc = await JsonDocument.ParseAsync(stream);
                var root = jsonDoc.RootElement;
                var quote = root.GetProperty("quote").GetString() ?? "Keep pushing forward.";
                var author = root.GetProperty("author").GetString() ?? "Unknown";
                return new ExternalQuoteDto(quote, author);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to fetch external quote via HttpClient. Using fallback quote.");
        }

        return new ExternalQuoteDto(
            "Clean architecture, robust dependency injection, and secure authorization are the pillars of scalable backends.",
            "Fundoo Notes Backend Team"
        );
    }
}
