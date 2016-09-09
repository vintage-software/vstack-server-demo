using System;
using Vstack.Services.Security;

namespace Domain.General
{
    public class DemoUserAuthenticationHelper
        : UserAuthenticationHelper
    {
        public DemoUserAuthenticationHelper()
            : base(45, TimeSpan.FromMinutes(5), TimeSpan.FromHours(1), 7)
        {
        }
    }
}
