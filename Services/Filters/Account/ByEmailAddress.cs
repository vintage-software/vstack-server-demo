using System.Linq;
using Vstack.Services.Filters;
using Dmn = Domain;

namespace Services.Filters.Account
{
    public class ByEmailAddress : IFilter<Dmn.Account>
    {
        private readonly string emailAddress;

        public ByEmailAddress(string emailAddress)
        {
            this.emailAddress = emailAddress;
        }

        public IQueryable<Dmn.Account> Filter(IQueryable<Dmn.Account> domains)
        {
            return domains.Where(account => account.EmailAddress.ToLower() == this.emailAddress.ToLower());
        }
    }
}
