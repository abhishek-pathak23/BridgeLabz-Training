using Microsoft.EntityFrameworkCore;

namespace ModelLayer.Context;

/// <summary>
/// EF Core DbContext for FundooNotesApp Day-14.
/// Contains Users and Notes tables.
/// </summary>
public class FundooDbContext : DbContext
{
    public FundooDbContext(DbContextOptions<FundooDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Note> Notes => Set<Note>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Users: Unique email index
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue("User");

        // Notes: FK to Users (cascade delete when user is removed)
        modelBuilder.Entity<Note>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notes)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
