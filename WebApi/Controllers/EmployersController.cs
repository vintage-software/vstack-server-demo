using Services.Converters;
using Services.DtoServices;
using Services.Mappers;
using Services.Services;
using Dto = Services.Dto;

namespace WebApi.Controllers
{
    public class EmployersController
        : BaseController<Dto.Employer, Domain.Employer, EmployerMapper, EmployerConverter, EmployerService, EmployerDtoService>
    {
    }
}
