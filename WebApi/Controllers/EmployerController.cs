using Services.Converters;
using Services.DtoServices;
using Services.Mappers;
using Services.Services;
using Dto = Services.Dto;

namespace WebApi.Controllers
{
    public class EmployerController
        : BaseController<Dto.Employer, Domain.Employer, EmployerMapper, EmployerConverter, EmployerService, EmployerDtoService>
    {
    }
}
