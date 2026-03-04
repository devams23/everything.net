using System.Security.Claims;
using Event_management_Project.Common.Exceptions;

namespace Event_management_Project.Common;

public static class UserContextExtensions
{
    public static int GetRequiredUserId(this ClaimsPrincipal user)
    {
        string? value = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.FindFirstValue(ClaimTypes.Name) ?? user.FindFirstValue(ClaimTypes.Sid) ?? user.FindFirstValue("sub");
        if (!int.TryParse(value, out int userId))
        {
            throw new ApiException(401, "Invalid user identity.", "invalid_identity");
        }

        return userId;
    } 

    public static string GetRequiredRole(this ClaimsPrincipal user)
    {
        string? role = user.FindFirstValue(ClaimTypes.Role);
        if (string.IsNullOrWhiteSpace(role))
        {
            throw new ApiException(401, "Role claim missing.", "invalid_identity");
        }

        return role;
    }
}
