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

// Dynamically read connection string & H2 DB configuration from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Data Source=mem:EmployeePayrollDb;DB_CLOSE_DELAY=-1";
var h2Config = builder.Configuration.GetSection("H2Database");

// Configure EF Core DbContext with dynamic database provider settings
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseInMemoryDatabase(connectionString));

// Register Layered Architecture Dependencies (DI)
builder.Services.AddScoped<IEmployeeRL, EmployeeRL>();
builder.Services.AddScoped<IEmployeeBL, EmployeeBL>();

var app = builder.Build();

// Ensure DB schema is initialized
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Payroll App API v1");
    c.RoutePrefix = "swagger";
});

app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapControllers();

app.Run();

public partial class Program { }
