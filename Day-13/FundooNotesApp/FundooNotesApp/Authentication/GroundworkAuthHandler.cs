using System.Security.Claims;
using System.Text.Encodings.Web;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace FundooNotesApp.Authentication;

public class GroundworkAuthOptions : AuthenticationSchemeOptions
{
}

public class GroundworkAuthHandler : AuthenticationHandler<GroundworkAuthOptions>
{
    public const string SchemeName = "GroundworkBearer";
    private readonly IAuthService _authService;

    public GroundworkAuthHandler(
        IOptionsMonitor<GroundworkAuthOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IAuthService authService) : base(options, logger, encoder)
    {
        _authService = authService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string? token = null;

        // Check Authorization header
        if (Request.Headers.TryGetValue("Authorization", out var authHeaderValues))
        {
            token = authHeaderValues.ToString().Trim();
            Logger.LogInformation("GroundworkAuthHandler: Received Authorization Header: {Header}", token);
        }
        else if (Request.Headers.TryGetValue("X-Auth-Token", out var customTokenHeader))
        {
            token = customTokenHeader.ToString().Trim();
            Logger.LogInformation("GroundworkAuthHandler: Received X-Auth-Token Header: {Header}", token);
        }

        if (string.IsNullOrWhiteSpace(token))
        {
            Logger.LogWarning("GroundworkAuthHandler: No Authorization or X-Auth-Token header found in request.");
            return AuthenticateResult.NoResult();
        }

        // Strip surrounding quotes if present
        token = token.Trim('"', '\'');

        // Robustly strip any leading "Bearer " or "GroundworkBearer " prefixes (handles accidental "Bearer Bearer ...")
        while (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase) ||
               token.StartsWith("GroundworkBearer ", StringComparison.OrdinalIgnoreCase))
        {
            var spaceIndex = token.IndexOf(' ');
            if (spaceIndex > 0)
            {
                token = token[(spaceIndex + 1)..].Trim().Trim('"', '\'');
            }
            else
            {
                break;
            }
        }

        var user = await _authService.ValidateGroundworkTokenAsync(token);
        if (user == null)
        {
            Logger.LogWarning("GroundworkAuthHandler: Token validation failed for token: {Token}", token);
            return AuthenticateResult.Fail("Invalid or expired groundwork authentication token.");
        }

        Logger.LogInformation("GroundworkAuthHandler: Authentication successful for User '{Email}' (Id: {Id}, Role: {Role})", user.Email, user.Id, user.Role);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new("sub", user.Id.ToString()),
            new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new(ClaimTypes.Email, user.Email),
            new("email", user.Email),
            new(ClaimTypes.Role, user.Role),
            new("role", user.Role),
            new("user_id", user.Id.ToString()),
            new("created_at", user.CreatedAt.ToString("O"))
        };

        var identity = new ClaimsIdentity(claims, SchemeName, ClaimTypes.Name, ClaimTypes.Role);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, SchemeName);

        return AuthenticateResult.Success(ticket);
    }
}
