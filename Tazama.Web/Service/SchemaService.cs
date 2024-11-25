using Json.Schema;
using Tazama.Web.Data;

namespace Tazama.Web.Service;

public class SchemaService(ISchemaRepository schemaRepository) : ISchemaService
{
    public async Task<bool> ValidateSchemaAsync(string schemaContent)
    {
        try
        {
            // Attempt to parse the schema to ensure it's valid
            var schema = JsonSchema.FromText(schemaContent);
            return schema != null;
        }
        catch (Exception)
        {
            // Invalid schema format
            return false;
        }
    }

    public async Task<string> SaveSchemaAsync(string schemaContent)
    {
        // Generate a unique schema key (e.g., a GUID)
        var schemaKey = Guid.NewGuid().ToString("N");

        // Create the schema entity
        var schemaEntity = new SchemaEntity
        {
            SchemaId = Guid.NewGuid().ToString("N"),
            SchemaKey = schemaKey,
            SchemaContent = schemaContent,
            DateUploaded = DateTime.UtcNow,
            // UserId = "OptionalUserId" // If using user accounts
        };

        // Save the schema entity using the repository
        await schemaRepository.SaveSchemaAsync(schemaEntity);

        return schemaKey;
    }

    public async Task<string> GetSchemaByKeyAsync(string schemaKey)
    {
        // Retrieve the schema entity from the repository
        var schemaEntity = await schemaRepository.GetSchemaByKeyAsync(schemaKey);

        if (schemaEntity != null)
        {
            return schemaEntity.SchemaContent;
        }
        else
        {
            // Schema not found
            return null;
        }
    }
}
