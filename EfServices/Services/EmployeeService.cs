using Domain;
using Services.Mappers;
using Vstack.Services.Services;

namespace Services.Services
{
    public class EmployeeService : BaseService<Employee, EmployeeMapper>
    {
        public EmployeeService()
            : base(new EmployeeMapper())
        {
        }
    }
}
