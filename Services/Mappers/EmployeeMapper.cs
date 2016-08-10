using Domain;
using Services.Persistence;
using Vstack.Services.Mappers;

namespace Services.Mappers
{
    public class EmployeeMapper : BaseEfAndStoredProcMapper<DbContext, Employee>
    {
        public EmployeeMapper()
            : base(new DbContext("Demo"))
        {
        }
    }
}
