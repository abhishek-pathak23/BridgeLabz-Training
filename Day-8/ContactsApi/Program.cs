using ContactsApi.Data;
using ContactsApi.Models;
using ContactsApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure H2 Database Connection & Register Repository Layer
var jdbcUrl = "jdbc:h2:mem:contactsdb;DB_CLOSE_DELAY=-1";
builder.Services.AddSingleton<IContactRepository>(sp => new ContactRepository(jdbcUrl));

var app = builder.Build();

// Initialize H2 Database Schema & Seed Sample Data
var dbInitializer = new DatabaseInitializer(jdbcUrl);
await dbInitializer.InitializeAsync();

// Enable Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts Minimal API (H2 DB)");
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
