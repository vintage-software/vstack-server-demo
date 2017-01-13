using Services.General;
using System.Linq;

namespace WebApi.Authentication
{
    public static class ClaimsConverter
    {
        public static Claims Convert(System.Security.Claims.ClaimsIdentity domain)
        {
            return new Claims()
            {
                AccountId = GetIntClaim(domain, ClaimType.AccountId)
            };
        }

        private static string GetClaim(System.Security.Claims.ClaimsIdentity claims, ClaimType type)
        {
            return claims.Claims.FirstOrDefault(i => i.Type == type.ToString())?.Value;
        }

        private static int? GetIntClaim(System.Security.Claims.ClaimsIdentity claims, ClaimType type)
        {
            int temp;
            string value = GetClaim(claims, type);
            return int.TryParse(value, out temp) ? (int?)temp : null;
        }
    }
}
