using Microsoft.EntityFrameworkCore;

namespace ModelLayer.Context;

public class FundooDbContext : DbContext
{
    public FundooDbContext(DbContextOptions<FundooDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ensure unique index on Email
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}
