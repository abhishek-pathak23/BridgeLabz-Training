using BusinessLayer.Interface;

namespace BusinessLayer.Service;

public class ExternalQuoteService : IExternalQuoteService
{
    private readonly HttpClient _httpClient;

    public ExternalQuoteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetDailyInspirationalQuoteAsync()
    {
        try
        {
            // Demonstrates HttpClient consuming external REST API
            var response = await _httpClient.GetAsync("https://api.quotable.io/random");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }
        catch
        {
            // Fallback quote if external network is unavailable
        }

        return "{\"content\":\"Security is not a product, but a process.\",\"author\":\"Bruce Schneier\"}";
    }
}
