using ContactsApi.Data;
using ContactsApi.Models;
using ContactsApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure EF Core with SQL Server (Connection string from appsettings.json)
builder.Services.AddDbContext<ContactsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repository Layer
builder.Services.AddScoped<IContactRepository, EfContactRepository>();

var app = builder.Build();

// Apply any pending EF Core Migrations and seed the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ContactsDbContext>();
    dbContext.Database.Migrate();
}

// Enable Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API (EF Core)");
    c.RoutePrefix = "swagger";
});

app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

// Minimal API Endpoints Definitions
var contactsApi = app.MapGroup("/api/contacts").WithTags("Contacts Minimal API");

// GET /api/contacts - Get all contacts with optional search/category filter
contactsApi.MapGet("/", async (IContactRepository repo, string? search, string? category) =>
{
    var contacts = await repo.GetAllAsync(search, category);
    return Results.Ok(contacts);
});

// GET /api/contacts/{id} - Get contact by ID
contactsApi.MapGet("/{id:int}", async (int id, IContactRepository repo) =>
{
    var contact = await repo.GetByIdAsync(id);
    return contact is not null 
        ? Results.Ok(contact) 
        : Results.NotFound(new { Message = $"Contact {id} not found." });
});

// POST /api/contacts - Create contact
contactsApi.MapPost("/", async (CreateContactDto dto, IContactRepository repo) =>
{
    var newContact = new Contact
    {
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Email = dto.Email,
        PhoneNumber = dto.PhoneNumber,
        Category = string.IsNullOrWhiteSpace(dto.Category) ? "Personal" : dto.Category,
        CreatedAt = DateTime.UtcNow
    };

    var created = await repo.CreateAsync(newContact);
    return Results.Created($"/api/contacts/{created.Id}", created);
});

// PUT /api/contacts/{id} - Update contact
contactsApi.MapPut("/{id:int}", async (int id, UpdateContactDto dto, IContactRepository repo) =>
{
    var contactToUpdate = new Contact
    {
        Id = id,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Email = dto.Email,
        PhoneNumber = dto.PhoneNumber,
        Category = string.IsNullOrWhiteSpace(dto.Category) ? "Personal" : dto.Category
    };

    var updated = await repo.UpdateAsync(contactToUpdate);
    return updated is not null 
        ? Results.Ok(updated) 
        : Results.NotFound(new { Message = $"Contact {id} not found." });
});

// DELETE /api/contacts/{id} - Delete contact
contactsApi.MapDelete("/{id:int}", async (int id, IContactRepository repo) =>
{
    var deleted = await repo.DeleteAsync(id);
    return deleted 
        ? Results.Ok(new { Message = $"Contact {id} successfully deleted." }) 
        : Results.NotFound(new { Message = $"Contact {id} not found." });
});

app.Run();

public partial class Program { } // Needed for WebApplicationFactory testing
