using Services.Dto;
using Vstack.Services.Converters;

namespace Services.Converters
{
    public class EmployerConverter
        : BaseConverter<Employer, Domain.Employer, General.Permissions>
    {
        protected override Employer Convert()
        {
            return new Employer()
            {
                Id = this.Domain.Id,
                Name = this.Domain.Name,
                Employees = this.GetEmployees()
            };
        }

        private Employee[] GetEmployees()
        {
            return this.HandlePermissions(
                hasPermissions: true,
                domain: i => i.Employees,
                dto: i => i.Employees,
                converter: new EmployeeConverter());
        }
    }
}
