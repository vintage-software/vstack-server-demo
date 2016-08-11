using Domain;
using Microsoft.AspNet.Identity;
using Services.EF.General;
using Services.EF.Services;
using System.Linq;
using System.Security.Claims;
using Vstack.Legacy.Api.Startup;
using Vstack.Services.Security;

namespace WebApi.EF.Authentication
{
    public class ClaimsProvider : IClaimsProvider<Permissions>
    {
        private readonly EmployeeService employeeService = new EmployeeService();

        public ClaimsIdentity GetClaims(int userId)
        {
            Employee employee = this.LoadEmployee(userId);

            int employeeId = userId;

            ClaimsIdentity claims = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            claims.AddClaims(new Claim[] {
                new Claim(VstackClaimTypes.UserId, employee.Id.ToString()),
                new Claim(VstackClaimTypes.SecurityStamp, employee.SecurityStamp),
                new Claim(ClaimType.EmployeeId.ToString(), employeeId.ToString())
            });

            return claims;
        }

        public ClaimsIdentity GetSuperClaims(int superUserId)
        {
            return null;
        }

        public Permissions GetPermissions(ClaimsIdentity claims)
        {
            return new Permissions(GetIntClaim(claims, ClaimType.EmployeeId));
        }

        private Employee LoadEmployee(int employeeId)
        {
            return this.employeeService.Get(employeeId)
                .FirstOrDefault();
        }

        private static int? GetIntClaim(ClaimsIdentity claims, ClaimType type)
        {
            int temp;
            string value = GetClaim(claims, type);
            return int.TryParse(value, out temp) ? (int?)temp : null;
        }

        private static string GetClaim(ClaimsIdentity claims, ClaimType type)
        {
            return claims.Claims.FirstOrDefault(i => i.Type == type.ToString())?.Value;
        }
    }
}