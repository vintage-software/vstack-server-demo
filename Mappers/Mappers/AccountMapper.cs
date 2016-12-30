using Domain;
using Vstack.Services.Mappers;

namespace Persistence.Mappers
{
    public class AccountMapper : BaseEfMapper<DbContext, Account>
    {
        public AccountMapper()
            : base(new DbContext())
        {
        }
    }
}
