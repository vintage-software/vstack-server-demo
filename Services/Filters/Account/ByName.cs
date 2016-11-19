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
            string lowerFirstName = this.firstName.ToLower();
            string lowerLastName = this.lastName.ToLower();

            return domains.Where(account => account.FirstName.ToLower() == lowerFirstName && account.LastName.ToLower() == lowerLastName);
        }
    }
}
