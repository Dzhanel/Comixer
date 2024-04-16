using System.Security.Claims;

namespace Comixer.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static Guid Id(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
