using Domain.General;
using Services.Mappers;
using Vstack.Services.General;
using Vstack.Services.Security;
using Vstack.Services.Services;
using Dmn = Domain;

namespace Services.Services
{
    public class EmployeeService : BaseService<Dmn.Employee, EmployeeMapper>
    {
        private readonly UserAuthenticationHelper userAuthenticationHelper = new DemoUserAuthenticationHelper();

        public EmployeeService()
            : base(new EmployeeMapper())
        {
        }

        public AuthenticationStatus AuthenticateWithPassword(Dmn.Employee employee, string password)
        {
            employee.ValidateDomainParameter(nameof(employee));

            AuthenticationStatus authenticateStatus = this.userAuthenticationHelper.Authenticate(employee, password);
            RestStatus saveResult = this.Save(employee).Status;

            if (saveResult != RestStatus.Success)
            {
                authenticateStatus = AuthenticationStatus.Failure;
            }

            return authenticateStatus;
        }
    }
}
