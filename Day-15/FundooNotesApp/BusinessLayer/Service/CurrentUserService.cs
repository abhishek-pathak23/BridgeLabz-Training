using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;

namespace BusinessLayer.Service;

/// <summary>
/// Day-14: CurrentUserService — reads JWT claims from HttpContext.User.
/// ASP.NET JWT middleware automatically validates the token and populates
/// HttpContext.User with the decoded claims before any controller action runs.
/// </summary>
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
    {
        _httpContextAccessor = httpContextAccessor;
        _configuration       = configuration;
    }

    public ClaimsPrincipal? UserPrincipal => _httpContextAccessor.HttpContext?.User;
    public bool IsAuthenticated => UserPrincipal?.Identity?.IsAuthenticated ?? false;

    /// <summary>
    /// UserId extracted from JWT 'sub' claim.
    /// This is why we put UserId (not name) in the JWT — it's unique & immutable.
    /// </summary>
    public int? UserId
    {
        get
        {
            var val = UserPrincipal?.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                   ?? UserPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                   ?? UserPrincipal?.FindFirst("user_id")?.Value;
            return int.TryParse(val, out var id) ? id : null;
        }
    }

    /// <summary>Email extracted from JWT 'email' claim — used for display/logging.</summary>
    public string? Email =>
        UserPrincipal?.FindFirst(JwtRegisteredClaimNames.Email)?.Value
        ?? UserPrincipal?.FindFirst(ClaimTypes.Email)?.Value;

    public string? Role =>
        UserPrincipal?.FindFirst(ClaimTypes.Role)?.Value
        ?? UserPrincipal?.FindFirst("role")?.Value;

    // ─── JWT Debugger ─────────────────────────────────────────────────────────

    /// <summary>
    /// Day-14 JWT Debugger: Decodes the raw JWT token and returns the Header,
    /// Payload and all resolved ASP.NET claims for inspection.
    /// Equivalent to pasting the token into https://jwt.io
    /// </summary>
    public JwtDebugDto GetJwtDebugInfo(string rawToken)
    {
        var resolvedClaims = new Dictionary<string, string>();
        if (UserPrincipal?.Claims != null)
        {
            foreach (var c in UserPrincipal.Claims)
                resolvedClaims[c.Type] = c.Value;
        }

        try
        {
            var handler = new JwtSecurityTokenHandler();

            // Decode without validation (purely for display — like jwt.io)
            var jwt = handler.ReadJwtToken(rawToken);

            var header = new
            {
                Algorithm = jwt.Header.Alg,
                Type      = jwt.Header.Typ
            };

            var payload = new
            {
                sub         = jwt.Subject,
                email       = jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value,
                given_name  = jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.GivenName)?.Value,
                family_name = jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.FamilyName)?.Value,
                role        = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value,
                jti         = jwt.Id,
                iss         = jwt.Issuer,
                aud         = jwt.Audiences.FirstOrDefault(),
                iat         = new DateTimeOffset(jwt.IssuedAt).ToUnixTimeSeconds(),
                exp         = new DateTimeOffset(jwt.ValidTo).ToUnixTimeSeconds(),
                exp_readable = jwt.ValidTo.ToString("O")
            };

            return new JwtDebugDto
            {
                Header         = header,
                Payload        = payload,
                ResolvedClaims = resolvedClaims,
                UserId         = UserId,
                Email          = Email,
                Role           = Role,
                IsAuthenticated = IsAuthenticated,
                Hint = "Paste your JWT token into https://jwt.io — you will see the same Header & Payload decoded there."
            };
        }
        catch
        {
            // If token decoding fails, still return resolved ASP.NET claims
            return new JwtDebugDto
            {
                ResolvedClaims  = resolvedClaims,
                UserId          = UserId,
                Email           = Email,
                Role            = Role,
                IsAuthenticated = IsAuthenticated,
                Hint = "Could not decode raw token. Paste it into https://jwt.io to inspect."
            };
        }
    }
}
