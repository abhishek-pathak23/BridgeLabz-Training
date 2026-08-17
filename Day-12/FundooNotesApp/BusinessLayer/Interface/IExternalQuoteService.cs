namespace BusinessLayer.Interface;

public interface IExternalQuoteService
{
    Task<string> GetDailyInspirationalQuoteAsync();
}
