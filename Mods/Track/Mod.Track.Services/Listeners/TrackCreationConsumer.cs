using MassTransit;
using Microsoft.Extensions.Logging;
using Mod.Track.EventData.Events;

namespace Mod.Track.Services.Listeners;

public class TrackCreationConsumer : IConsumer<TrackCreatedEvent>
{
    public readonly ILogger<TrackCreationConsumer> _logger;

    public TrackCreationConsumer(ILogger<TrackCreationConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<TrackCreatedEvent> context)
    {
        _logger.LogInformation(context.Message.Description);
    }
}