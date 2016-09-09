using System.Linq;
using Vstack.Services.Filters;
using Dmn = Domain;

namespace Services.Filters.Employee
{
    public class ByName : IFilter<Dmn.Employee>
    {
        private readonly string name;

        public ByName(string name)
        {
            this.name = name;
        }

        public IQueryable<Dmn.Employee> Filter(IQueryable<Dmn.Employee> domains)
        {
            return domains.Where(i => i.Name == this.name);
        }
    }
}
