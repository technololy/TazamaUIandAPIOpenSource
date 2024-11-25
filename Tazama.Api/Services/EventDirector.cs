using System.Text.Json;

namespace Tazama.Api.Services;

public interface IEventDirector
{
    Task ProcessEventAsync(string eventType, JsonElement eventData);
}

public class EventDirector : IEventDirector
{
    private readonly IDictionary<string, IEventProcessor> _processors;

    public EventDirector(IEnumerable<IEventProcessor> processors)
    {
        _processors = processors.ToDictionary(p => p.EventType, p => p);
    }

    public async Task ProcessEventAsync(string eventType, JsonElement eventData)
    {
        if (_processors.TryGetValue(eventType, out var processor))
        {
            await processor.ProcessAsync(eventData);
        }
        else
        {
            throw new Exception($"No processor found for event type {eventType}");
        }
    }
}
