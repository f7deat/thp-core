using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using THPCore.Interfaces;

namespace THPCore.Services;

public class HCAService(IHttpContextAccessor _httpContextAccessor) : IHCAService
{
    public IEnumerable<string>? GetRoles()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user is null || user.Identity is null) return default;

        return user.FindAll(ClaimTypes.Role).Select(x => x.Value);
    }

    public bool IsUserInRole(string roleName)
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user is null || user.Identity is null) return false;

        return user.IsInRole(roleName);
    }

    public bool IsUserInAnyRole(params string[] roles)
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user == null || user.Identity is null) return false;

        return roles.Any(user.IsInRole);
    }

    public string GetUserId()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
    }

    public string GetUserName()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        return user?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
    }

    public bool HasClaim(string claimType, string? claimValue = null)
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null || !user.Identity?.IsAuthenticated == true) return false;

        if (string.IsNullOrEmpty(claimValue)) return user.HasClaim(c => c.Type == claimType);

        return user.HasClaim(c => c.Type == claimType && c.Value == claimValue);
    }

    public string? GetClaimValue(string claimType)
    {
        var user = _httpContextAccessor?.HttpContext?.User;
        return user?.FindFirst(claimType)?.Value;
    }
}
