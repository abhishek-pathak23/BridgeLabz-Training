using System.Security.Claims;
using ModelLayer;

namespace BusinessLayer.Interface;

public interface ICurrentUserService
{
    int? UserId { get; }
    string? Email { get; }
    string? Role { get; }
    bool IsAuthenticated { get; }
    ClaimsPrincipal? UserPrincipal { get; }
    ClaimsDebugDto GetClaimsDebugInfo();
}
