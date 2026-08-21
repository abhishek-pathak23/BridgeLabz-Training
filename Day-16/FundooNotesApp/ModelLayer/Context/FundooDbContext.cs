using Microsoft.EntityFrameworkCore;

namespace ModelLayer.Context;

/// <summary>
/// EF Core DbContext for FundooNotesApp.
/// Day-14: Users + Notes tables.
/// Day-16: Added Labels + NoteLabels (many-to-many join table).
/// </summary>
public class FundooDbContext : DbContext
{
    public FundooDbContext(DbContextOptions<FundooDbContext> options) : base(options)
    {
    }

    public DbSet<User>      Users      => Set<User>();
    public DbSet<Note>      Notes      => Set<Note>();
    public DbSet<Label>     Labels     => Set<Label>();
    public DbSet<NoteLabel> NoteLabels => Set<NoteLabel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ── Users ──────────────────────────────────────────────────────────
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue("User");

        // ── Notes: FK to Users (cascade delete when user is removed) ───────
        modelBuilder.Entity<Note>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notes)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // ── Labels ────────────────────────────────────────────────────────
        // Unique label name per user
        modelBuilder.Entity<Label>()
            .HasIndex(l => new { l.UserId, l.Name })
            .IsUnique();

        modelBuilder.Entity<Label>()
            .HasOne(l => l.User)
            .WithMany()
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict); // prevent cascade conflict

        // ── NoteLabels: composite PK + FK config ──────────────────────────
        modelBuilder.Entity<NoteLabel>()
            .HasKey(nl => new { nl.NoteId, nl.LabelId });

        modelBuilder.Entity<NoteLabel>()
            .HasOne(nl => nl.Note)
            .WithMany(n => n.NoteLabels)
            .HasForeignKey(nl => nl.NoteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NoteLabel>()
            .HasOne(nl => nl.Label)
            .WithMany(l => l.NoteLabels)
            .HasForeignKey(nl => nl.LabelId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
