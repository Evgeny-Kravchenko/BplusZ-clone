using System.Linq;
using System.Security.Claims;

namespace Synnotech_BplusZ.WebApi.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string? GetRole(this ClaimsPrincipal principal)
        {
            return principal.Claims?.Where(claim => claim.Type == ClaimTypes.Role)
                .Select(claim => claim.Value)
                .FirstOrDefault();
        }
    }
}
