using EmployeeAPI_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed  data
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@email.com", Position = "Developer" },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@email.com", Position = "Manager" }
            );
        }
    }
}