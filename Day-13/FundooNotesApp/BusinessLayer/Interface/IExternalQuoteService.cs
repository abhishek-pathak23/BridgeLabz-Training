namespace BusinessLayer.Interface;

public record ExternalQuoteDto(string Quote, string Author);

public interface IExternalQuoteService
{
    Task<ExternalQuoteDto> GetDailyInspirationalQuoteAsync();
}
