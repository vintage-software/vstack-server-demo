using Persistence.Mappers;
using Services.Converters;
using Services.DtoServices;
using Services.Services;
using Dto = Services.Dto;

namespace WebApi.Controllers
{
    public class AccountsController
        : BaseController<Dto.Account, Domain.Account, AccountMapper, AccountConverter, AccountService, AccountDtoService>
    {
        public AccountsController(AccountDtoService dtoService)
            : base (dtoService)
        {
        }
    }
}
