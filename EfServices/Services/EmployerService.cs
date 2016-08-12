using Domain;
using Services.Mappers;
using Vstack.Services.Services;

namespace Services.Services
{
    public class EmployerService : BaseService<Employer, EmployerMapper>
    {
        public EmployerService()
            : base(new EmployerMapper())
        {
        }
    }
}
