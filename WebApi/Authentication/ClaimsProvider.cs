using Domain;
using Microsoft.AspNet.Identity;
using Services.General;
using Services.Services;
using System.Linq;
using System.Security.Claims;
using Vstack.Api.Startup;
using Vstack.Services.Security;
using WebApi.App_Start;

namespace WebApi.Authentication
{
    public class ClaimsProvider : IClaimsProvider<Permissions>
    {
        private readonly AccountService accountService = AutofacResolver.Instance.Resolve<AccountService>();

        public ClaimsIdentity GetClaims(int userId)
        {
            Account account = this.LoadAccount(userId);

            int accountId = userId;

            ClaimsIdentity claims = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);

            claims.AddClaims(new Claim[] {
                new Claim(VstackClaimTypes.UserId, account.Id.ToString()),
                new Claim(VstackClaimTypes.SecurityStamp, account.SecurityStamp),
                new Claim(ClaimType.AccountId.ToString(), accountId.ToString())
            });

            return claims;
        }

        public ClaimsIdentity GetSuperClaims(int superUserId)
        {
            return null;
        }

        public Permissions GetPermissions(ClaimsIdentity claims)
        {
            return new Permissions(ClaimsConverter.Convert(claims));
        }

        private Account LoadAccount(int accountId)
        {
            return this.accountService.Get(accountId)
                .FirstOrDefault();
        }
    }
}