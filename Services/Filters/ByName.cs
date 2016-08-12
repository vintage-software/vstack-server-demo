using Domain;
using System.Linq;
using Vstack.Services.Filters;

namespace Services.Filters
{
    public class ByName : IFilter<Employee>
    {
        private readonly string name;

        public ByName(string name)
        {
            this.name = name;
        }

        public IQueryable<Employee> Filter(IQueryable<Employee> domains)
        {
            return domains.Where(i => i.Name == this.name);
        }
    }
}
