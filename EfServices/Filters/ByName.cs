using Domain;
using Services.EF.Mappers;
using System.Linq;
using Vstack.Extensions;
using Vstack.Services.Filters;

namespace Services.EF.Filters
{
    public class ByName : IPrimaryFilter<Employee, EmployeeMapper>
    {
        private readonly string name;

        public ByName(string name)
        {
            this.name = name;
        }

        public IQueryable<Employee> PrimaryFilter(EmployeeMapper mapper)
        {
            mapper.ValidateNotNullParameter(nameof(mapper));

            return mapper.DbSet
                .Where(i => i.Name == this.name);
        }
    }
}
