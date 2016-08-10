using Domain;
using System.Linq;
using Vstack.Services.Filters;

namespace Services.EF.Filters
{
    public class ByName : ISecondaryFilter<Employee>
    {
        private readonly string name;

        public ByName(string name)
        {
            this.name = name;
        }

        public IQueryable<Employee> SecondaryFilter(IQueryable<Employee> domains)
        {
            return domains.Where(i => i.Name == this.name);
        }
    }
}
