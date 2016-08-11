using Domain;
using System.Data.Entity;
using Vstack.Services.Data.EntityFramework;

namespace Services.EF.Persistence
{
    public class DbContext : VstackEfDbContext
    {
        public DbContext()
            : base("EfDemo")
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Employer> Employers { get; set; }
    }
}
