using Services.EF.Converters;
using Services.EF.DtoServices;
using Services.EF.Mappers;
using Services.EF.Services;
using Dto = Services.EF.Dto;

namespace WebApi.Controllers
{
    public class EmployerController
        : BaseController<Dto.Employer, Domain.Employer, EmployerMapper, EmployerConverter, EmployerService, EmployerDtoService>
    {
    }
}
