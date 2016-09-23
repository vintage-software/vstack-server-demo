using System;
using Vstack.Services.Security;

namespace Domain.General
{
    public class NoteApplicationUserAuthenticationHelper
        : UserAuthenticationHelper
    {
        public NoteApplicationUserAuthenticationHelper()
            : base(45, TimeSpan.FromMinutes(5), TimeSpan.FromHours(1), 7)
        {
        }
    }
}
