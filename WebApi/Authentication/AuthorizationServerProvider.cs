using Domain;
using Microsoft.Owin.Security.OAuth;
using Services.Filters.Account;
using Services.General;
using Services.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Vstack.Services.Security;

namespace WebApi.Authentication
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly AccountService employeeService = new AccountService();

        private readonly ClaimsProvider claimsProvider = new ClaimsProvider();

        protected SignInManager SignInManager
        {
            get
            {
                return new SignInManager(HttpContext.Current.GetOwinContext().Authentication);
            }
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            Permissions permissions = this.claimsProvider.GetPermissions(context.Identity);
            context.AdditionalResponseParameters.Add("userId", permissions.GetAccountId());
            return base.TokenEndpointResponse(context);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            this.GrantUserCredentials(context);
            return base.GrantResourceOwnerCredentials(context);
        }

        private void GrantUserCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            Account employee = this.employeeService.Get()
                .Filter(new ByEmailAddress(context.UserName))
                .FirstOrDefault();

            if (employee != null)
            {
                AuthenticationStatus status = this.employeeService.AuthenticateWithPassword(employee, context.Password);

                if (status == AuthenticationStatus.Success)
                {
                    this.SignInManager.SignIn(employee.Id, false);
                    ClaimsIdentity claims = this.claimsProvider.GetClaims(employee.Id);
                    context.Validated(claims);
                }

                return;
            }

            context.Rejected();
        }
    }
}