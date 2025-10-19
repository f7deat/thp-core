using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using THPCore.Interfaces;

namespace THPCore.Services;

/// <inheritdoc/>
public class HCAService(IHttpContextAccessor _httpContextAccessor) : IHCAService
{
    /// <inheritdoc/>
    public IEnumerable<string>? GetRoles()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user is null || user.Identity is null) return default;

        return user.FindAll(ClaimTypes.Role).Select(x => x.Value);
    }

    /// <inheritdoc/>
    public bool IsUserInRole(string roleName)
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user is null || user.Identity is null) return false;

        return user.IsInRole(roleName);
    }

    /// <inheritdoc/>
    public bool IsUserInAnyRole(params string[] roles)
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user == null || user.Identity is null) return false;

        return roles.Any(user.IsInRole);
    }

    /// <inheritdoc/>
    public string GetUserId()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
    }

    /// <inheritdoc/>
    public string GetUserName()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        return user?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
    }

    /// <inheritdoc/>
    public bool HasClaim(string claimType, string? claimValue = null)
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null || !user.Identity?.IsAuthenticated == true) return false;

        if (string.IsNullOrEmpty(claimValue)) return user.HasClaim(c => c.Type == claimType);

        return user.HasClaim(c => c.Type == claimType && c.Value == claimValue);
    }

    /// <inheritdoc/>
    public string? GetClaimValue(string claimType)
    {
        var user = _httpContextAccessor?.HttpContext?.User;
        return user?.FindFirst(claimType)?.Value;
    }

    /// <inheritdoc/>
    public IEnumerable<string> GetAllClaimValues(string claimType)
    {
        var user = _httpContextAccessor?.HttpContext?.User;
        if (user is null || user.Identity is null) return [];
        return user.FindAll(claimType).Select(x => x.Value);
    }
}
