using Domain.General;
using Persistence.Mappers;
using Vstack.Services.General;
using Vstack.Services.Security;
using Vstack.Services.Services;
using Dmn = Domain;

namespace Services.Services
{
    public class AccountService : BaseService<Dmn.Account, AccountMapper>
    {
        private readonly UserAuthenticationHelper userAuthenticationHelper = new NoteApplicationUserAuthenticationHelper();

        public AccountService()
            : base(new AccountMapper())
        {
        }

        public AuthenticationStatus AuthenticateWithPassword(Dmn.Account account, string password)
        {
            account.ValidateDomainParameter(nameof(account));

            AuthenticationStatus authenticateStatus = this.userAuthenticationHelper.Authenticate(account, password);
            RestStatus saveResult = this.Save(account).Status;

            if (saveResult != RestStatus.Success)
            {
                authenticateStatus = AuthenticationStatus.Failure;
            }

            return authenticateStatus;
        }
    }
}
