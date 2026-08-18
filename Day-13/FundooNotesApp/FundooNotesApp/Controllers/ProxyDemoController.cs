using Microsoft.AspNetCore.Mvc;

namespace FundooNotesApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProxyDemoController : ControllerBase
{
    /// <summary>
    /// GET /api/ProxyDemo/echo - Inspect resolved client IP, forwarded proxy headers, host, and scheme
    /// </summary>
    [HttpGet("echo")]
    public IActionResult EchoProxyHeaders()
    {
        var headers = HttpContext.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());

        var forwardedFor = Request.Headers["X-Forwarded-For"].FirstOrDefault();
        var forwardedProto = Request.Headers["X-Forwarded-Proto"].FirstOrDefault();
        var forwardedHost = Request.Headers["X-Forwarded-Host"].FirstOrDefault();
        var forwardedPrefix = Request.Headers["X-Forwarded-Prefix"].FirstOrDefault();

        return Ok(new
        {
            Message = "Reverse Proxy Header Resolution Diagnostic",
            ResolvedConnection = new
            {
                RemoteIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                RemotePort = HttpContext.Connection.RemotePort,
                LocalIpAddress = HttpContext.Connection.LocalIpAddress?.ToString(),
                LocalPort = HttpContext.Connection.LocalPort
            },
            ResolvedRequest = new
            {
                Scheme = Request.Scheme,
                Host = Request.Host.Value,
                Path = Request.Path.Value,
                PathBase = Request.PathBase.Value,
                IsHttps = Request.IsHttps
            },
            ForwardedHeadersDetected = new
            {
                XForwardedFor = forwardedFor ?? "(Not provided / Handled by UseForwardedHeaders)",
                XForwardedProto = forwardedProto ?? "(Not provided / Handled by UseForwardedHeaders)",
                XForwardedHost = forwardedHost ?? "(Not provided / Handled by UseForwardedHeaders)",
                XForwardedPrefix = forwardedPrefix ?? "(Not provided)"
            },
            AllIncomingHeaders = headers,
            ConceptExplanation = "When running behind a reverse proxy (such as Nginx, Cloudflare, YARP, or IIS), the proxy forwards the original client IP and protocol via X-Forwarded-* headers. The UseForwardedHeaders middleware automatically maps these headers into HttpContext.Connection and HttpContext.Request."
        });
    }
}
