using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Data;

public class ContactsDbContext : DbContext
{
    public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data (using fixed DateTime values — required for EF Core Migrations)
        modelBuilder.Entity<Contact>().HasData(
            new Contact { Id = 1, FirstName = "Abhishek", LastName = "Pathak", Email = "abhi@example.com", PhoneNumber = "1234567890", Category = "Work", CreatedAt = new DateTime(2026, 8, 12, 0, 0, 0, DateTimeKind.Utc) },
            new Contact { Id = 2, FirstName = "Ananya", LastName = "Sharma", Email = "ananya@example.com", PhoneNumber = "0987654321", Category = "Personal", CreatedAt = new DateTime(2026, 8, 12, 0, 0, 0, DateTimeKind.Utc) },
            new Contact { Id = 3, FirstName = "Rahul", LastName = "Verma", Email = "rahul@example.com", PhoneNumber = "1122334455", Category = "Work", CreatedAt = new DateTime(2026, 8, 12, 0, 0, 0, DateTimeKind.Utc) },
            new Contact { Id = 4, FirstName = "Priya", LastName = "Patel", Email = "priya@example.com", PhoneNumber = "5544332211", Category = "Personal", CreatedAt = new DateTime(2026, 8, 12, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
