using System.Linq;
using Vstack.Services.Filters;
using Dmn = Domain;

namespace Services.Filters.Account
{
    public class ByName : IFilter<Dmn.Account>
    {
        private readonly string firstName;
        private readonly string lastName;

        public ByName(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public IQueryable<Dmn.Account> Filter(IQueryable<Dmn.Account> domains)
        {
            return domains.Where(i => i.FirstName.ToLower() == this.firstName.ToLower() && i.LastName.ToLower() == this.lastName.ToLower());
        }
    }
}
