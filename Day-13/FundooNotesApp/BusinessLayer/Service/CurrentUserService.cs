using System.Security.Claims;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using ModelLayer;

namespace BusinessLayer.Service;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ClaimsPrincipal? UserPrincipal => _httpContextAccessor.HttpContext?.User;

    public bool IsAuthenticated => UserPrincipal?.Identity?.IsAuthenticated ?? false;

    public int? UserId
    {
        get
        {
            var idClaim = UserPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                          ?? UserPrincipal?.FindFirst("sub")?.Value
                          ?? UserPrincipal?.FindFirst("UserId")?.Value;

            return int.TryParse(idClaim, out var id) ? id : null;
        }
    }

    public string? Email =>
        UserPrincipal?.FindFirst(ClaimTypes.Email)?.Value
        ?? UserPrincipal?.FindFirst("email")?.Value;

    public string? Role =>
        UserPrincipal?.FindFirst(ClaimTypes.Role)?.Value
        ?? UserPrincipal?.FindFirst("role")?.Value;

    public ClaimsDebugDto GetClaimsDebugInfo()
    {
        var claims = new Dictionary<string, string>();
        if (UserPrincipal?.Claims != null)
        {
            foreach (var claim in UserPrincipal.Claims)
            {
                // Handle duplicate claim types by suffixing or updating
                claims[claim.Type] = claim.Value;
            }
        }

        return new ClaimsDebugDto
        {
            Subject = UserId?.ToString() ?? "Anonymous",
            Email = Email ?? "Anonymous",
            Role = Role ?? "None",
            IsAuthenticated = IsAuthenticated,
            AuthenticationType = UserPrincipal?.Identity?.AuthenticationType ?? "None",
            Claims = claims
        };
    }
}
