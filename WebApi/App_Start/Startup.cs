using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Services.General;
using System;
using System.Web;
using Vstack.Extensions;
using Vstack.Legacy.Api.Startup;
using WebApi.Authentication;

[assembly: OwinStartup(typeof(WebApi.App_Start.Startup))]

namespace WebApi.App_Start
{
    public class Startup
        : VstackStartup<Permissions>
    {
        protected override TimeSpan IntervalToCheckForUpdatedSecurityStamp
        {
            get
            {
                return TimeSpan.FromMinutes(30);
            }
        }

        protected override TimeSpan KeepMeLoggedInTimeSpan
        {
            get
            {
                return TimeSpan.FromDays(30);
            }
        }

        protected override string LogOnPath
        {
            get
            {
                return "/login.aspx";
            }
        }

        protected override IClaimsProvider<Permissions> ClaimsProvider
        {
            get
            {
                return new ClaimsProvider();
            }
        }

        protected override IOAuthAuthorizationServerProvider AuthorizationServerProvider
        {
            get
            {
                return new AuthorizationServerProvider();
            }
        }

        public void Configuration(IAppBuilder app)
        {
            this.SetupAuthentication(app);
        }

        protected override void OnApplyRedirect(CookieApplyRedirectContext context)
        {
            context.ValidateNotNullParameter(nameof(context));

            if (IsWebApiRequest(context.Request) == false)
            {
                context.Response.Redirect(context.RedirectUri);
            }
        }

        private static bool IsWebApiRequest(IOwinRequest request)
        {
            return request.Uri.LocalPath.StartsWith(VirtualPathUtility.ToAbsolute($"~/api/"));
        }
    }
}