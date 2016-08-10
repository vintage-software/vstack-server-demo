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
            context.ValidateNotNullParameter(nameof(context));

            context.Employees.Add(new Employee("Ted"));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
