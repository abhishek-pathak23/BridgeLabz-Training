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

// Configure EF Core DbContext with SQL Server / EF Provider Lifecycle
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    try
    {
        options.UseSqlServer(connectionString);
    }
    catch
    {
        // Fallback for environment flexibility
        options.UseSqlServer(connectionString);
    }
});

// Register Layered Architecture Dependencies (DI Lifecycle)
builder.Services.AddScoped<IEmployeeRL, EmployeeRL>();
builder.Services.AddScoped<IEmployeeBL, EmployeeBL>();

var app = builder.Build();

// EF Core Schema evolution workflow: Automatically apply migrations & initialize DB
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var context = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
    try
    {
        logger.LogInformation("Applying EF Core Migrations and initializing EmployeeDbContext...");
        context.Database.Migrate();
        logger.LogInformation("EF Core Migrations applied successfully.");
    }
    catch (Exception ex)
    {
        logger.LogWarning(ex, "Could not apply SQL Server migrations automatically. Falling back to EnsureCreated.");
        context.Database.EnsureCreated();
    }
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Day 11 Employee Payroll App API v1");
    c.RoutePrefix = "swagger";
});

app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapControllers();

app.Run();

public partial class Program { }
