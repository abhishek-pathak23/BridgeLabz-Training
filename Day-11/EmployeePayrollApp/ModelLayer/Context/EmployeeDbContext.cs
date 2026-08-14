using Microsoft.EntityFrameworkCore;

namespace ModelLayer.Context;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Initial Data for EF Core Migrations
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Department = "Engineering",
                Salary = 75000.00m,
                Email = "john.doe@company.com",
                CreatedAt = new DateTime(2026, 1, 15, 0, 0, 0, DateTimeKind.Utc)
            },
            new Employee
            {
                Id = 2,
                Name = "Jane Smith",
                Department = "Human Resources",
                Salary = 65000.00m,
                Email = "jane.smith@company.com",
                CreatedAt = new DateTime(2026, 2, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Employee
            {
                Id = 3,
                Name = "Michael Brown",
                Department = "Finance",
                Salary = 80000.00m,
                Email = "michael.brown@company.com",
                CreatedAt = new DateTime(2026, 3, 10, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}
