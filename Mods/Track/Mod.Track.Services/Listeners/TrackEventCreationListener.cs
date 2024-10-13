using Core.Base.ConfigurationInterfaces;
using Infrastructure.Services;
using Mod.Track.Models;
using Serilog;

namespace Mod.Track.Services.Listeners;

public class TrackEventCreationListener: ConsumeRabbitMQHostedService<TrackModel>
{
    public TrackEventCreationListener(ILogger logger, IMessageBrokerConfiguration configuration) : base(logger, configuration)
    {
    }
}