using Domain;
using System.Data.Entity;
using Vstack.Extensions;

namespace Services.EF.Persistence
{
    public class Initializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            context.ValidateNotNullParameter(nameof(context));

            context.Employees.Add(new Employee("Ted"));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
