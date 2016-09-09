using Domain;
using System.Data.Entity;
using Vstack.Extensions;

namespace Services.Persistence
{
    public class Initializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            context.ValidateNotNullParameter(nameof(context));

            Employer employer = new Employer("Flannigan Corp");
            context.Employers.Add(employer);
            context.SaveChanges();

            context.Employees.Add(new Employee(employer.Id, "ted@example.com", "Ted", "555-55-5555", "Password123"));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
