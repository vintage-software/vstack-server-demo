using Domain;
using Services.EF.Mappers;
using Vstack.Services.Services;

namespace Services.EF.Services
{
    public class EmployerService : BaseService<Employer, EmployerMapper>
    {
        public EmployerService()
            : base(new EmployerMapper())
        {
        }
    }
}
