using Domain;
using System.Reflection;
using Vstack.Extensions;
using Vstack.Services.Data.EntityFramework;
using Vstack.Services.Filters;

namespace Services.Persistence
{
    public class Initializer : VstackDbInitializer<DbContext>
    {
        public Initializer(Assembly assembly)
            : base(
                  assembly.GetChildInstances<IEntityEqualityStoredProcedurePrimaryFilter>(),
                  assembly.GetChildInstances<IEntityCustomStoredProcedurePrimaryFilter>())
        {
        }

        protected override void Seed(DbContext context)
        {
            if (!context.IsInitialized())
            {
                return;
            }

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
