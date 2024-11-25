namespace Tazama.Web.Service;

public interface ISchemaService
{
    /// <summary>
    /// Validates the given JSON schema content.
    /// </summary>
    /// <param name="schemaContent">The JSON schema as a string.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the schema is valid.</returns>
    Task<bool> ValidateSchemaAsync(string schemaContent);

    /// <summary>
    /// Saves the JSON schema and returns a unique schema key.
    /// </summary>
    /// <param name="schemaContent">The JSON schema as a string.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the unique schema key.</returns>
    Task<string> SaveSchemaAsync(string schemaContent);

    /// <summary>
    /// Retrieves the JSON schema content associated with the given schema key.
    /// </summary>
    /// <param name="schemaKey">The unique schema key.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the JSON schema content.</returns>
    Task<string> GetSchemaByKeyAsync(string schemaKey);
}
