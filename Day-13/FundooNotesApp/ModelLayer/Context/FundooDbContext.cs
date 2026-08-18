using Microsoft.EntityFrameworkCore;

namespace ModelLayer.Context;

public class FundooDbContext : DbContext
{
    public FundooDbContext(DbContextOptions<FundooDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ensure unique constraint on Email
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Default value for Role
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue("User");
    }
}
