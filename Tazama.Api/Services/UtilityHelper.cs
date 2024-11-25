using System.Text.Json.Nodes;
using Json.Schema;

namespace Tazama.Api.Services;

public class UtilityHelper
{
    public static bool ValidateJson(string jsonData, string schemaData)
    {
        var schema = JsonSchema.FromText(schemaData);
        var json = JsonNode.Parse(jsonData);

        var validationResults = schema.Evaluate(json);

        return validationResults.IsValid;
    }
}