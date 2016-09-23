using System.Collections.Generic;
using System.Linq;
using Vstack.Services.General;
using Vstack.Services.Services;

namespace Services.DtoServices
{
    public class EmployerDtoService
        : BaseUndeletedSingleDtoService<Dto.Employer, Domain.Employer, Mappers.EmployerMapper, Converters.EmployerConverter, Services.EmployerService, General.Permissions>
    {
        public EmployerDtoService()
            : this(General.Permissions.Empty)
        {
        }

        public EmployerDtoService(General.Permissions permissions)
            : base(new Services.EmployerService(), permissions, false)
        {
        }

        protected override DtoRestStatus CanDelete(Domain.Employer domain)
        {
            return this.Permissions.IsSuperUser() ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanRead(IEnumerable<int> ids)
        {
            return ids.All(id => this.Permissions.HasPermissionsForEmployer(id)) ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanReadAll()
        {
            return DtoRestStatus.BadRequest;
        }

        protected override DtoActionResult<Domain.Employer> Construct(Dto.Employer dto)
        {
            if (this.Permissions.HasPermissionsForEmployer(dto.Id) == false)
            {
                return new DtoActionResult<Domain.Employer>(DtoRestStatus.Forbidden);
            }

            Domain.Employer domain = new Domain.Employer(dto.Name);
            return new DtoActionResult<Domain.Employer>(DtoRestStatus.Success, domain);
        }

        protected override DtoRestStatus Update(Domain.Employer domain, Dto.Employer dto)
        {
            if (this.Permissions.HasPermissionsForEmployer(domain.Id) == false)
            {
                return DtoRestStatus.Forbidden;
            }

            domain.ChangeName(dto.Name);

            return DtoRestStatus.Success;
        }
    }
}
