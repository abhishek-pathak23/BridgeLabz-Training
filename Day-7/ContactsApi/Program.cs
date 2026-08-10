using ContactsApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Register Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IContactService, ContactService>();

var app = builder.Build();

// Configure Middleware Pipeline - Enable Swagger UI in all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts Minimal API v1");
    c.RoutePrefix = "swagger"; // Available at http://localhost:5000/swagger
});

// Redirect root / to /swagger
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

// Minimal API Endpoints Definitions (Directly in Program.cs)
var contactsApi = app.MapGroup("/api/contacts")
                     .WithTags("Contacts Minimal API");

// GET /api/contacts - Retrieve all contacts with search & category filter
contactsApi.MapGet("/", async (IContactService contactService, string? search, string? category) =>
{
    var contacts = await contactService.GetAllAsync(search, category);
    return Results.Ok(contacts);
})
.WithName("GetAllContacts")
.WithSummary("Get all contacts with optional search and category filters")
.Produces<IEnumerable<Contact>>(StatusCodes.Status200OK);

// GET /api/contacts/{id} - Retrieve contact by ID
contactsApi.MapGet("/{id:int}", async (int id, IContactService contactService) =>
{
    var contact = await contactService.GetByIdAsync(id);
    return contact is not null 
        ? Results.Ok(contact) 
        : Results.NotFound(new { Message = $"Contact with ID {id} not found." });
})
.WithName("GetContactById")
.WithSummary("Get contact details by ID")
.Produces<Contact>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

// POST /api/contacts - Create a new contact
contactsApi.MapPost("/", async (CreateContactDto dto, IContactService contactService) =>
{
    var created = await contactService.CreateAsync(dto);
    return Results.Created($"/api/contacts/{created.Id}", created);
})
.WithName("CreateContact")
.WithSummary("Create a new contact")
.Produces<Contact>(StatusCodes.Status201Created)
.ProducesValidationProblem();

// PUT /api/contacts/{id} - Update an existing contact
contactsApi.MapPut("/{id:int}", async (int id, UpdateContactDto dto, IContactService contactService) =>
{
    var updated = await contactService.UpdateAsync(id, dto);
    return updated is not null 
        ? Results.Ok(updated) 
        : Results.NotFound(new { Message = $"Contact with ID {id} not found." });
})
.WithName("UpdateContact")
.WithSummary("Update an existing contact by ID")
.Produces<Contact>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.ProducesValidationProblem();

// DELETE /api/contacts/{id} - Delete contact
contactsApi.MapDelete("/{id:int}", async (int id, IContactService contactService) =>
{
    var deleted = await contactService.DeleteAsync(id);
    return deleted 
        ? Results.Ok(new { Message = $"Contact {id} successfully deleted." }) 
        : Results.NotFound(new { Message = $"Contact with ID {id} not found." });
})
.WithName("DeleteContact")
.WithSummary("Delete contact by ID")
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.Run();
