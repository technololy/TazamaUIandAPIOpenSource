using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Tazama.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DynamicDataController : ControllerBase
{
    [HttpPost("{endpoint}")]
    public IActionResult PostData(string endpoint, [FromBody] JsonElement data)
    {
        if (string.IsNullOrEmpty(endpoint))
        {
            return BadRequest("Endpoint is required.");
        }

        ProcessData(endpoint, data);

        return Ok(new { Message = "Data processed successfully." });
    }

    private void ProcessData(string endpoint, JsonElement data)
    {
        if (data.TryGetProperty("property1", out JsonElement prop1))
        {
            var value = prop1.GetString();
            // Further processing...
        }

        // Route to appropriate handler based on endpoint or data content
    }
}
