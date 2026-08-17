using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Context;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure EF Core with SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FundooDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register HttpClient for external API consumption (Day-12 WebAPI REST Verbs & HttpClient concept)
builder.Services.AddHttpClient<IExternalQuoteService, ExternalQuoteService>();

// Register Layered Architecture Dependencies (DI Lifecycle)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// EF Core Migrations: automatically apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var context = scope.ServiceProvider.GetRequiredService<FundooDbContext>();
    try
    {
        logger.LogInformation("Applying EF Core Migrations for FundooNotesApp Day-12...");
        context.Database.Migrate();
        logger.LogInformation("EF Core Migrations applied successfully.");
    }
    catch (Exception ex)
    {
        logger.LogWarning(ex, "Could not apply SQL Server migrations. Falling back to EnsureCreated.");
        context.Database.EnsureCreated();
    }
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fundoo Notes App API - Day 12");
    c.RoutePrefix = "swagger";
});

app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
app.MapControllers();

app.Run();

public partial class Program { }
