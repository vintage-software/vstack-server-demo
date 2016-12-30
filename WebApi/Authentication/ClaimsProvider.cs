﻿using Domain;
using Microsoft.AspNet.Identity;
using Services.General;
using Services.Services;
using System.Linq;
using System.Security.Claims;
using Vstack.Api.General;
using Vstack.Api.Startup;
using Vstack.Services.Security;

namespace WebApi.Authentication
{
    public class ClaimsProvider : IClaimsProvider<Permissions>
    {
        private readonly AccountService accountService = new AccountService();

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

        public Permissions GetPermissions(ClaimsIdentity claimsIdentity)
        {
            return new Permissions(claimsIdentity.GetIntClaim(ClaimType.AccountId.ToString()));
        }

        private Account LoadAccount(int accountId)
        {
            return this.accountService.Get(accountId)
                .FirstOrDefault();
        }
    }
}