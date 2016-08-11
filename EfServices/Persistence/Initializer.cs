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

            Employer employer = new Employer("Flannigan Corp");
            context.Employers.Add(employer);
            context.SaveChanges();

            context.Employees.Add(new Employee(employer.Id, "Ted", "555-55-5555", "Password123"));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
