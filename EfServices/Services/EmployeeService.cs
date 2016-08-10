using Domain;
using Services.EF.Mappers;
using Vstack.Services.Services;

namespace Services.EF.Services
{
    public class EmployeeService : BaseService<Employee, EmployeeMapper>
    {
        public EmployeeService()
            : base(new EmployeeMapper())
        {
        }
    }
}
