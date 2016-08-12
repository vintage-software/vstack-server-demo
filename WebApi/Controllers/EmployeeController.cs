using Services.Converters;
using Services.DtoServices;
using Services.Mappers;
using Services.Services;
using Dto = Services.Dto;

namespace WebApi.Controllers
{
    public class EmployeeController
        : BaseController<Dto.Employee, Domain.Employee, EmployeeMapper, EmployeeConverter, EmployeeService, EmployeeDtoService>
    {
    }
}
