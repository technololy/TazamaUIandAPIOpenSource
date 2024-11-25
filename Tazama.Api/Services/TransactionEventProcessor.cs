using System.Text.Json;

namespace Tazama.Api.Services;

public interface IEventProcessor
{
    string EventType { get; }
    Task ProcessAsync(JsonElement eventData);
}

public class TransactionEventProcessor : IEventProcessor
{
    public string EventType => "TxTp";

    public Task ProcessAsync(JsonElement eventData)
    {
        // Process transaction event data
        // Apply rules, update models, generate alerts, etc.
        return Task.CompletedTask;
    }
}
