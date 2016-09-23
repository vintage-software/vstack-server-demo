using System.Collections.Generic;
using System.Linq;
using Vstack.Services.General;
using Vstack.Services.Services;
using Dmn = Domain;

namespace Services.DtoServices
{
    public class AccountDtoService
        : BaseUndeletedSingleDtoService<Dto.Account, Dmn.Account, Mappers.AccountMapper, Converters.AccountConverter, Services.AccountService, General.Permissions>
    {
        public AccountDtoService()
            : this(General.Permissions.Empty)
        {
        }

        public AccountDtoService(General.Permissions permissions)
            : base(new Services.AccountService(), permissions, false)
        {
        }

        protected override DtoRestStatus CanDelete(Dmn.Account domain)
        {
            return this.Permissions.IsInternal() ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanRead(IEnumerable<int> ids)
        {
            return ids.All(id => this.Permissions.HasPermissionsForAccount(id)) ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanReadAll()
        {
            return DtoRestStatus.BadRequest;
        }

        protected override DtoActionResult<Dmn.Account> Construct(Dto.Account dto)
        {
            Dmn.Account domain = new Dmn.Account(dto.EmailAddress, dto.FirstName, dto.LastName, dto.Password);

            return new DtoActionResult<Dmn.Account>(DtoRestStatus.Success, domain);
        }

        protected override DtoRestStatus Update(Dmn.Account domain, Dto.Account dto)
        {
            if (this.Permissions.HasPermissionsForAccount(domain.Id) == false)
            {
                return DtoRestStatus.Forbidden;
            }

            domain.SetName(dto.FirstName, dto.LastName);

            return DtoRestStatus.Success;
        }
    }
}
