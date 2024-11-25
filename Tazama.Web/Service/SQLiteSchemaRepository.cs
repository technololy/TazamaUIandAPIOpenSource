using Tazama.Web.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tazama.Web.Service;

public class SQLiteSchemaRepository(ApplicationDbContext dbContext) : ISchemaRepository
{
    public async Task SaveSchemaAsync(SchemaEntity schemaEntity)
    {
        dbContext.Schemas.Add(schemaEntity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<SchemaEntity> GetSchemaByKeyAsync(string schemaKey)
    {
        return await dbContext.Schemas
            .FirstOrDefaultAsync(s => s.SchemaKey == schemaKey);
    }
}
