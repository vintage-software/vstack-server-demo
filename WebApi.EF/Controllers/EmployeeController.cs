using Services.EF.Converters;
using Services.EF.DtoServices;
using Services.EF.Mappers;
using Services.EF.Services;
using Dto = Services.EF.Dto;

namespace WebApi.Controllers
{
    public class EmployeeController
        : BaseController<Dto.Employee, Domain.Employee, EmployeeMapper, EmployeeConverter, EmployeeService, EmployeeDtoService>
    {
    }
}
