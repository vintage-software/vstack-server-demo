using System.Collections.Generic;
using System.Linq;
using Vstack.Services.General;
using Vstack.Services.Services;

namespace Services.DtoServices
{
    public class EmployeeDtoService
        : BaseUndeletedDtoService<Dto.Employee, Domain.Employee, Mappers.EmployeeMapper, Converters.EmployeeConverter, Services.EmployeeService, General.Permissions>
    {
        public EmployeeDtoService()
            : this(General.Permissions.Empty)
        {
        }

        public EmployeeDtoService(General.Permissions permissions)
            : base(new Services.EmployeeService(), permissions, false)
        {
        }

        protected override DtoRestStatus CanDelete(Domain.Employee domain)
        {
            return this.Permissions.IsSuperUser() ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanRead(IEnumerable<int> ids)
        {
            return ids.All(id => this.Permissions.HasPermissionsForEmployee(id)) ? DtoRestStatus.Success : DtoRestStatus.Forbidden;
        }

        protected override DtoRestStatus CanReadAll()
        {
            return DtoRestStatus.BadRequest;
        }

        protected override DtoActionResult<Domain.Employee> Construct(Dto.Employee dto)
        {
            if (this.Permissions.HasPermissionsForEmployer(dto.EmployerId) == false)
            {
                return new DtoActionResult<Domain.Employee>(DtoRestStatus.Forbidden);
            }

            Domain.Employee domain = new Domain.Employee(dto.EmployerId, dto.Name, dto.SocialSecurityNumber, dto.Password);
            return new DtoActionResult<Domain.Employee>(DtoRestStatus.Success, domain);
        }

        protected override DtoRestStatus Update(Domain.Employee domain, Dto.Employee dto)
        {
            bool isEmployer = this.Permissions.HasPermissionsForEmployer(domain.EmployerId);
            bool isEmployee = this.Permissions.HasPermissionsForEmployee(domain.Id);

            if (isEmployer == false && isEmployee == false)
            {
                return DtoRestStatus.Forbidden;
            }

            if (this.Permissions.IsSuperUser())
            {
                domain.UpdateInternalNotes(this.Permissions.GetSuperUserId().Value, dto.InternalNotes);
            }

            if (isEmployer)
            {
                domain.UpdateAnnualSalary(dto.AnnualSalary);
            }

            if (isEmployee)
            {
                domain.ChangePassword(dto.Password);
            }

            domain.ChangeName(dto.Name);

            return DtoRestStatus.Success;
        }
    }
}
