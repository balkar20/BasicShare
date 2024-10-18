using Data.Base.Objects;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.Track.Base.Repositories;
using Mod.Track.EventData.Aggregates;
using Mod.Track.Interfaces;
using Mod.Track.Services;
using MongoDataServices;

namespace Mod.Track.Root.AppServices;

public class ModTrackServicesConfigurator
{
    private readonly IServiceCollection _services;
    
    public ModTrackServicesConfigurator(IServiceCollection services)
    {
        _services = services;
    }

    public void Configure()
    {
        // _services.AddSingleton<ITrackRepository, TrackSqlRepository>();
        _services.AddSingleton<ITrackWriteService, TrackWriteService>();
        _services.AddSingleton<IAggregateRepository<TrackAggregate>, AggregateRepository<TrackAggregate>>();
        _services.AddSingleton<IAggregateStorage, AggregateStorage>();
        _services.AddSingleton<IMessageBusService, MessageBusService>();
        _services.AddSingleton<IDataCollectionService<EventDocument>, DataCollectionService<EventDocument>>();
    }
}