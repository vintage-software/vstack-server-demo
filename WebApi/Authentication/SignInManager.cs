using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Services.General;
using System.Security.Claims;

namespace WebApi.Authentication
{
    public class SignInManager
    {
        private readonly IAuthenticationManager authenticationManager;

        private readonly ClaimsProvider claimsProvider = new ClaimsProvider();

        public SignInManager(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        public void SignIn(int employeeId, bool isPersistent)
        {
            ClaimsIdentity identity = this.claimsProvider.GetClaims(employeeId);
            Permissions permissions = this.claimsProvider.GetPermissions(identity);
            this.authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public void SuperSignIn(int superUserId)
        {
            ClaimsIdentity identity = this.claimsProvider.GetSuperClaims(superUserId);
            Permissions permissions = this.claimsProvider.GetPermissions(identity);
            this.authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);
        }

        public void SignOut()
        {
            this.authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}