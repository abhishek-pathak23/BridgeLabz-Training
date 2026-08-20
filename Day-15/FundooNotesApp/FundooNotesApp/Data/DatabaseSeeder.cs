using BusinessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using ModelLayer.Context;

namespace FundooNotesApp.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(FundooDbContext context, IPasswordHasher passwordHasher, ILogger logger)
    {
        if (await context.Users.AnyAsync(u => u.Email == "abhishek.pathak@fundoonotes.com"))
        {
            logger.LogInformation("Database already contains seed users. Skipping seeding.");
            return;
        }

        logger.LogInformation("Seeding default users into FundooNotesDb_Day14...");

        var seedUsers = new List<(string First, string Last, string Email, string Password, string Role)>
        {
            ("Abhishek", "Pathak", "abhishek.pathak@fundoonotes.com", "Password@123", "Admin"),
            ("Ananya",   "Sharma", "ananya.sharma@fundoonotes.com",   "Password@123", "User"),
            ("Rahul",    "Verma",  "rahul.verma@fundoonotes.com",     "Password@123", "User"),
            ("Priya",    "Patel",  "priya.patel@fundoonotes.com",     "Password@123", "User"),
            ("Vikram",   "Singh",  "vikram.singh@fundoonotes.com",    "Password@123", "Admin")
        };

        foreach (var (first, last, email, password, role) in seedUsers)
        {
            if (!await context.Users.AnyAsync(u => u.Email == email))
            {
                passwordHasher.CreatePasswordHash(password, out byte[] hash, out byte[] salt);
                context.Users.Add(new User
                {
                    FirstName    = first,
                    LastName     = last,
                    Email        = email,
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    Role         = role,
                    CreatedAt    = DateTime.UtcNow
                });
            }
        }

        await context.SaveChangesAsync();
        logger.LogInformation("Seeded 5 default users into FundooNotesDb_Day14.");
    }
}
