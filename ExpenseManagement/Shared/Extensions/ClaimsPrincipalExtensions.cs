using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Shared.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }
            return principal.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static string GetEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }
            return principal.FindFirstValue(ClaimTypes.Name);
        }
    }
}
