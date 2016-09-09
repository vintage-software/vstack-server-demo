using System.Linq;
using Vstack.Services.Filters;
using Dmn = Domain;

namespace Services.Filters.Employee
{
    public class ByEmailAddress : IFilter<Dmn.Employee>
    {
        private readonly string emailAddress;

        public ByEmailAddress(string emailAddress)
        {
            this.emailAddress = emailAddress;
        }

        public IQueryable<Dmn.Employee> Filter(IQueryable<Dmn.Employee> domains)
        {
            return domains.Where(i => i.EmailAddress == this.emailAddress);
        }
    }
}
