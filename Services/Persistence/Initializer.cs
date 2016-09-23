using Domain;
using System.Collections.Generic;
using System.Data.Entity;
using Vstack.Extensions;

namespace Services.Persistence
{
    public class Initializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            context.ValidateNotNullParameter(nameof(context));

            List<Account> accounts = new List<Account> {
                new Account("david@noteapplication.com", "David", "Pfeiffer", "Password123"),
                new Account("steve@noteapplication.com", "Steve", "Haar", "Password123"),
                new Account("kevin@noteapplication.com", "Kevin", "Phelps", "Password123"),
                new Account("hunter@noteapplication.com", "Hunter", "LaTourette", "Password123")
            };

            context.Accounts.AddRange(accounts);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
