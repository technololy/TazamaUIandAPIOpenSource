using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;
using Tazama.Api.Services;

namespace Tazama.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DynamicEndpointController(IEventDirector eventDirector) : ControllerBase
{
    [HttpPost("HandleEvent/{eventType}")]
    public async Task<IActionResult> HandleEvent(string eventType, [FromBody] JsonElement eventData)
    {
        if (string.IsNullOrEmpty(eventType))
        {
            return BadRequest("Event type is required.");
        }

        // Validate event data
        if (!ValidateEventData(eventType, eventData))
        {
            return BadRequest("Invalid event data.");
        }

        // Process the event through the Event Director
        await eventDirector.ProcessEventAsync(eventType, eventData);

        return Ok(new { Message = "Event processed successfully." });
    }

    private bool ValidateEventData(string eventType, JsonElement eventData)
    {
        // Implement validation logic based on eventType
        // For example, check required properties exist in eventData
        return UtilityHelper.ValidateJson("eventData", eventType);
    }
}
