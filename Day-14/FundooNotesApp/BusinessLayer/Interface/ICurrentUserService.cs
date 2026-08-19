using System.Security.Claims;
using ModelLayer;

namespace BusinessLayer.Interface;

/// <summary>
/// Provides the current authenticated user's identity extracted from JWT claims.
/// </summary>
public interface ICurrentUserService
{
    ClaimsPrincipal? UserPrincipal { get; }
    bool IsAuthenticated { get; }
    int? UserId { get; }
    string? Email { get; }
    string? Role { get; }
    JwtDebugDto GetJwtDebugInfo(string rawToken);
}
