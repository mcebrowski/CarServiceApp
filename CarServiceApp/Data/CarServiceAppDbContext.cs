using Microsoft.EntityFrameworkCore;
using CarServiceApp.Entities;


namespace CarServiceApp.Data
{
    public class CarServiceAppDbContext : DbContext
    {
        public CarServiceAppDbContext(DbContextOptions<CarServiceAppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

    }
}
