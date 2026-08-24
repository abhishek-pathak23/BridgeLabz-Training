using BusinessLayer.Interface;
using BusinessLayer.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Context;
using System.Text;
using FundooNotesApp.Data;
using NLog;
using NLog.Web;

// ── Day-16: Initialise NLog early so startup errors are also logged ──────────
var logger = LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

logger.Info("╔══════════════════════════════════════════════╗");
logger.Info("║  Fundoo Notes App — Day-17 (Reminder + RabbitMQ)  ║");
logger.Info("╚══════════════════════════════════════════════╝");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // ── 0. NLog as the logging provider ─────────────────────────────────────
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // ── 1. Controllers ───────────────────────────────────────────────────────
    builder.Services.AddControllers(options => 
    {
        options.Filters.Add<FundooNotesApp.Filters.GlobalExceptionFilter>();
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddHttpContextAccessor();

    // ── 2. Swagger with JWT Bearer Security + XML Doc Comments ───────────────
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
        {
            Title       = "Fundoo Notes App - Day 17",
            Version     = "v1",
            Description = "REST API for FundooNotes App."
        });

        // Include XML doc comments in Swagger
        var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            c.IncludeXmlComments(xmlPath);

        // Define the JWT Bearer security scheme for Swagger UI
        c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.OpenApiSecurityScheme
        {
            Description = "Enter your JWT token below. Format: 'Bearer {token}'\n\n" +
                          "Tip: Copy the 'token' from Login response and paste it here as: Bearer <token>",
            Name        = "Authorization",
            In          = Microsoft.OpenApi.ParameterLocation.Header,
            Type        = Microsoft.OpenApi.SecuritySchemeType.ApiKey,
            Scheme      = "Bearer"
        });

        // Use a document filter to correctly wire up the global security requirement
        c.DocumentFilter<FundooNotesApp.Authentication.BearerSecurityDocumentFilter>();
    });

    // ── 3. EF Core with SQL Server ───────────────────────────────────────────
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<FundooDbContext>(options =>
        options.UseSqlServer(connectionString));

    // ── 4. DI: Application Services ─────────────────────────────────────────
    builder.Services.AddFundooApplicationServices();

    // ── 4b. Day-17: RabbitMQ Background Consumer ─────────────────────────────
    builder.Services.AddHostedService<FundooNotesApp.BackgroundServices.ReminderConsumerService>();

    // ── 5. CORS ──────────────────────────────────────────────────────────────
    var allowedOrigins = builder.Configuration.GetSection("CorsOrigins").Get<string[]>()
                         ?? new[] { "http://localhost:3000", "http://localhost:4200", "http://localhost:5173" };

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("FundooFrontendPolicy", policy =>
            policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials());

        options.AddPolicy("AllowAll", policy =>
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    });

    // ── 6. JWT Authentication ────────────────────────────────────────────────
    var jwtSettings  = builder.Configuration.GetSection("Jwt");
    var secretKey    = jwtSettings["SecretKey"]!;
    var issuer       = jwtSettings["Issuer"]!;
    var audience     = jwtSettings["Audience"]!;

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateLifetime         = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer              = issuer,
            ValidAudience            = audience,
            IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ClockSkew                = TimeSpan.Zero   // No tolerance on expiry
        };
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        options.AddPolicy("UserOnly",  policy => policy.RequireRole("User", "Admin"));
    });

    // ── 6b. Day-17: Session Management ───────────────────────────────────────
    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

    // ── 7. Build App ─────────────────────────────────────────────────────────
    var app = builder.Build();

    // ── 8. Auto-migrate + Seed ───────────────────────────────────────────────
    using (var scope = app.Services.CreateScope())
    {
        var appLogger      = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        var context        = scope.ServiceProvider.GetRequiredService<FundooDbContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        try
        {
            appLogger.LogInformation("Applying EF Core Migrations for FundooNotesApp Day-17...");
            context.Database.Migrate();
            await DatabaseSeeder.SeedAsync(context, passwordHasher, appLogger);
        }
        catch (Exception ex)
        {
            appLogger.LogWarning(ex, "Migration failed. Falling back to EnsureCreated.");
            context.Database.EnsureCreated();
            await DatabaseSeeder.SeedAsync(context, passwordHasher, appLogger);
        }
    }

    // ── 9. Middleware Pipeline ────────────────────────────────────────────────
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fundoo Notes App - Day 17");
        c.RoutePrefix = "swagger";
    });

    app.UseCors("FundooFrontendPolicy");

    // Day-17: Session middleware
    app.UseSession();

    app.UseAuthentication();   // ← validates JWT, populates HttpContext.User with claims
    app.UseAuthorization();    // ← enforces [Authorize] policies / roles

    app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();
    app.MapControllers();

    logger.Info("Application started successfully — navigate to /swagger");
    app.Run();
}
catch (Exception ex)
{
    logger.Fatal(ex, "Application terminated unexpectedly");
    throw;
}
finally
{
    LogManager.Shutdown();  // flush NLog on exit
}

public partial class Program { }
