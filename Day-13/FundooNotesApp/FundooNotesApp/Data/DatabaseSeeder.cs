using BusinessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using ModelLayer.Context;

namespace FundooNotesApp.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(FundooDbContext context, IPasswordHasher passwordHasher, ILogger logger)
    {
        // 1. Check if seed users already exist
        if (await context.Users.AnyAsync(u => u.Email == "abhishek.pathak@fundoonotes.com"))
        {
            logger.LogInformation("Database already contains seed users. Skipping seeding.");
            return;
        }

        logger.LogInformation("Seeding default users into FundooNotesDb_Day13...");

        // 2. Default Seed Users
        var seedUsers = new List<(string FirstName, string LastName, string Email, string Password, string Role)>
        {
            ("Abhishek", "Pathak", "abhishek.pathak@fundoonotes.com", "Password@123", "Admin"),
            ("Ananya", "Sharma", "ananya.sharma@fundoonotes.com", "Password@123", "User"),
            ("Rahul", "Verma", "rahul.verma@fundoonotes.com", "Password@123", "User"),
            ("Priya", "Patel", "priya.patel@fundoonotes.com", "Password@123", "User"),
            ("Vikram", "Singh", "vikram.singh@fundoonotes.com", "Password@123", "Admin")
        };

        // 3. Encrypt passwords with salted HMAC-SHA512 & insert into SQL Server
        foreach (var (firstName, lastName, email, password, role) in seedUsers)
        {
            if (!await context.Users.AnyAsync(u => u.Email == email))
            {
                passwordHasher.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                context.Users.Add(new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = role,
                    CreatedAt = DateTime.UtcNow
                });
            }
        }

        await context.SaveChangesAsync();
        logger.LogInformation("Successfully seeded 5 users into FundooNotesDb_Day13.");
    }
}
