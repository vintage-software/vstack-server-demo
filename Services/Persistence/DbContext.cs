using Domain;
using System.Data.Entity;
using System.Reflection;
using Vstack.Services.Data.EntityFramework;

namespace Services.Persistence
{
    public class DbContext : VstackDbContext
    {
        public DbContext()
            : base("Demo")
        {
            Database.SetInitializer(new Initializer(Assembly.GetExecutingAssembly()));
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
