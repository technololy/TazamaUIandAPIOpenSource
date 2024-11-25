using Tazama.Web.Data;

namespace Tazama.Web.Service;

public interface ISchemaRepository
{
    /// <summary>
    /// Saves the schema entity to the data store.
    /// </summary>
    /// <param name="schemaEntity">The schema entity to save.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task SaveSchemaAsync(SchemaEntity schemaEntity);

    /// <summary>
    /// Retrieves the schema entity associated with the given schema key.
    /// </summary>
    /// <param name="schemaKey">The unique schema key.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the schema entity.</returns>
    Task<SchemaEntity> GetSchemaByKeyAsync(string schemaKey);
}