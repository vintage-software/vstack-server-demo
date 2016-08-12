using Domain;
using System.Data.Entity;
using Vstack.Services.Data.EntityFramework;

namespace Services.Persistence
{
    public class DbContext : VstackEfDbContext
    {
        public DbContext()
            : base("Demo")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Employer> Employers { get; set; }
    }
}
