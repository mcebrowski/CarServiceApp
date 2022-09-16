using Microsoft.EntityFrameworkCore;
using CarServiceApp.Entities;

namespace CarServiceApp.Data
{
    public class CarServiceAppDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<Client> Clients => Set<Client>();

        public DbSet<Visit> Visits => Set<Visit>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
