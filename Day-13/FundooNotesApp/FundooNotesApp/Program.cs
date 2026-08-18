using BusinessLayer.Extensions;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using FundooNotesApp.Authentication;
using FundooNotesApp.Data;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Context;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Controllers with JSON configuration
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

// 2. Swagger / OpenAPI Configuration with Security Definition for Groundwork Token
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Fundoo Notes App API - Day 13",
        Version = "v1",
    });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.OpenApiSecurityScheme
    {
        Description = "Enter 'Bearer {token}' (include the word Bearer followed by a space and your token).",
        Name = "Authorization",
        In = Microsoft.OpenApi.ParameterLocation.Header,
        Type = Microsoft.OpenApi.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Use a document filter to correctly wire up the global security requirement
    c.DocumentFilter<FundooNotesApp.Authentication.BearerSecurityDocumentFilter>();
});

// 3. Configure EF Core with SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FundooDbContext>(options =>
    options.UseSqlServer(connectionString));

// 4. Dependency Injection: Register Application Services (DI Deep-Dive & Structured Registration)
builder.Services.AddFundooApplicationServices();

// Register HttpClient for external API consumption
builder.Services.AddHttpClient<IExternalQuoteService, ExternalQuoteService>();

// 5. Reverse Proxy Configuration (ForwardedHeadersOptions)
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor
                             | ForwardedHeaders.XForwardedProto
                             | ForwardedHeaders.XForwardedHost;
    // Allow forwarded headers from reverse proxies (Nginx, IIS, YARP, Cloudflare)
    options.KnownIPNetworks.Clear();
    options.KnownProxies.Clear();
});

// 6. CORS (Cross-Origin Resource Sharing) Configuration
var allowedOrigins = builder.Configuration.GetSection("CorsOrigins").Get<string[]>()
                     ?? new[] { "http://localhost:3000", "http://localhost:4200", "http://localhost:5173" };

builder.Services.AddCors(options =>
{
    // Strict CORS Policy for Fundoo Frontend applications
    options.AddPolicy("FundooFrontendPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });

    // Public / Permissive CORS Policy
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 7. Authentication & Authorization Groundwork
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = GroundworkAuthHandler.SchemeName;
    options.DefaultChallengeScheme = GroundworkAuthHandler.SchemeName;
})
.AddScheme<GroundworkAuthOptions, GroundworkAuthHandler>(GroundworkAuthHandler.SchemeName, null);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User", "Admin"));
});

var app = builder.Build();

// 1. Pipeline Middleware: Reverse Proxy Header Forwarding (Must be FIRST in pipeline)
app.UseForwardedHeaders();

// 2. EF Core Migrations & Seed Data: Automatically apply migrations and seed users on startup
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var context = scope.ServiceProvider.GetRequiredService<FundooDbContext>();
    var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();
    try
    {
        logger.LogInformation("Applying EF Core Migrations for FundooNotesApp Day-13...");
        context.Database.Migrate();
        logger.LogInformation("EF Core Migrations applied successfully.");

        // Automatically seed default users from FundooNotesApp/Data/DatabaseSeeder.cs
        await DatabaseSeeder.SeedAsync(context, passwordHasher, logger);
    }
    catch (Exception ex)
    {
        logger.LogWarning(ex, "Could not apply SQL Server migrations. Falling back to EnsureCreated.");
        context.Database.EnsureCreated();
        await DatabaseSeeder.SeedAsync(context, passwordHasher, logger);
    }
}

// 3. Swagger UI configuration
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fundoo Notes App API - Day 13");
    c.RoutePrefix = "swagger";
});

// 4. CORS Middleware
app.UseCors("FundooFrontendPolicy");

// 5. Authentication & Authorization Middleware
app.UseAuthentication();
app.UseAuthorization();

// 6. Root auto-redirect to Swagger & Route mapping
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
app.MapControllers();

app.Run();

public partial class Program { }
