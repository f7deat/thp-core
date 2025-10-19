namespace THPCore.Interfaces;

/// <summary>
/// Provides methods for accessing and evaluating user-related information from the current HTTP context, including
/// roles, claims, and user identity details.
/// </summary>
public interface IHCAService
{
    /// <summary>
    /// Determines whether the current user belongs to the specified role.
    /// </summary>
    /// <remarks>This method checks the role membership of the user associated with the current HTTP context.
    /// If the HTTP context or user identity is unavailable, the method returns <see langword="false"/>.</remarks>
    /// <param name="roleName">The name of the role to check for membership.</param>
    /// <returns><see langword="true"/> if the current user is in the specified role; otherwise, <see langword="false"/>.</returns>
    bool IsUserInRole(string roleName);
    /// <summary>
    /// Retrieves the roles associated with the current user.
    /// </summary>
    /// <remarks>This method extracts role claims from the current user's identity within the HTTP context. If
    /// the HTTP context or user identity is unavailable, the method returns <see langword="null"/>.</remarks>
    /// <returns>An enumerable collection of role names if the user has role claims; otherwise, <see langword="null"/>.</returns>
    IEnumerable<string>? GetRoles();
    bool IsUserInAnyRole(params string[] roles);
    /// <summary>
    /// Retrieves the unique identifier of the currently authenticated user.
    /// </summary>
    /// <remarks>This method extracts the user ID from the claims of the current HTTP context. If no user is
    /// authenticated or the claim is not present, an empty string is returned.</remarks>
    /// <returns>The unique identifier of the authenticated user as a string, or an empty string if the user is not authenticated
    /// or the claim is missing.</returns>
    string GetUserId();
    string GetUserName();
    bool HasClaim(string claimType, string? claimValue = null);
    string? GetClaimValue(string claimType);
    /// <summary>
    /// Retrieves all claim values associated with the specified claim type.
    /// </summary>
    /// <param name="claimType">The type of claim for which to retrieve values. Cannot be null or empty.</param>
    /// <returns>An enumerable collection of strings representing the values of the specified claim type. The collection will be
    /// empty if no claims of the specified type are found.</returns>
    IEnumerable<string> GetAllClaimValues(string claimType);
}
