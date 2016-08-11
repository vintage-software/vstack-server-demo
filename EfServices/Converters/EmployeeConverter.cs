using Vstack.Services.Converters;

namespace Services.EF.Converters
{
    public class EmployeeConverter
        : BaseConverter<Dto.Employee, Domain.Employee, General.Permissions>
    {
        protected override Dto.Employee Convert()
        {
            return new Dto.Employee()
            {
                Id = this.Domain.Id,
                EmployerId = this.Domain.EmployerId,
                Name = this.Domain.Name,
                SocialSecurityNumber = this.GetSocialSecurityNumber(),
                AnnualSalary = this.GetAnnualSalary(),
                InternalNotes = this.GetInternalNotes(),
                Password = this.GetPassword(),
                Employer = this.GetEmployer()
            };
        }

        private string GetSocialSecurityNumber()
        {
            return this.HandlePermissions(
                hasPermissions: this.Permissions.HasPermissionsForEmployee(this.Domain.Id),
                domain: i => i.SocialSecurityNumber,
                dto: i => i.SocialSecurityNumber,
                autoInclude: true);
        }

        private string GetPassword()
        {
            return this.HandlePermissions(
                hasPermissions: false,
                domain: i => i.Password,
                dto: i => i.Password,
                autoInclude: true);
        }

        private decimal GetAnnualSalary()
        {
            return this.HandlePermissions(
                hasPermissions: this.Permissions.HasPermissionsForEmployee(this.Domain.Id)
                    || this.Permissions.HasPermissionsForEmployer(this.Domain.EmployerId),
                domain: i => i.AnnualSalary,
                dto: i => i.AnnualSalary,
                autoInclude: true);
        }

        private string GetInternalNotes()
        {
            return this.HandlePermissions(
                hasPermissions: this.Permissions.IsSuperUser(),
                domain: i => i.InternalNotes,
                dto: i => i.InternalNotes,
                autoInclude: true);
        }

        private Dto.Employer GetEmployer()
        {
            return this.HandlePermissions(
                hasPermissions: true,
                domain: i => i.Employer,
                dto: i => i.Employer,
                converter: new EmployerConverter());
        }
    }
}
