using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FundooNotesApp.Authentication;

/// <summary>
/// A simple document filter that adds a global security requirement for the "Bearer" scheme.
/// This ensures Swagger UI sends the Authorization header on every request after clicking Authorize.
/// </summary>
public class BearerSecurityDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // Create a reference to the "Bearer" security scheme defined via AddSecurityDefinition
        var schemeReference = new OpenApiSecuritySchemeReference("Bearer", swaggerDoc);

        var requirement = new OpenApiSecurityRequirement
        {
            [schemeReference] = new List<string>()
        };

        swaggerDoc.Security ??= new List<OpenApiSecurityRequirement>();
        swaggerDoc.Security.Add(requirement);
    }
}
