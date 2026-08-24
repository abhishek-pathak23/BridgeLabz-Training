using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FundooNotesApp.Filters;

/// <summary>
/// Day-17: Global Exception Filter
/// Catches unhandled exceptions across all controllers and returns a standardized JSON response.
/// </summary>
public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Unhandled exception caught by GlobalExceptionFilter.");

        var response = new
        {
            Message = "An unexpected error occurred. Please try again later.",
            Error = context.Exception.Message,
            StackTrace = context.Exception.StackTrace // In production, hide this!
        };

        context.Result = new ObjectResult(response)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
