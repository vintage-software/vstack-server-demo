using Domain;
using System.Data.Entity;
using Vstack.Services.Data.EntityFramework;

namespace Services.EF.Persistence
{
    public class DbContext : VstackEfDbContext
    {
        public DbContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
