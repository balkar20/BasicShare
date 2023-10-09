using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.Order.Base.Repositories;
using Mod.Order.EventData.Aggregates;
using Mod.Order.Interfaces;
using Mod.Order.Services;
using MongoDataServices;
using MongoObjects;

namespace Mod.Order.Root.AppServices;

public class ModOrderServicesConfigurator
{
    private readonly IServiceCollection _services;
    
    public ModOrderServicesConfigurator(IServiceCollection services)
    {
        _services = services;
    }

    public void Configure()
    {
        _services.AddSingleton<IOrderRepository, OrderSqlRepository>();
        _services.AddSingleton<IOrderWriteService, OrderWriteService>();
        _services.AddSingleton<IAggregateRepository<OrderAggregate>, AggregateRepository<OrderAggregate>>();
        _services.AddSingleton<IAggregateStorage, AggregateStorage>();
        _services.AddSingleton<IMessageBusService, MessageBusService>();
        _services.AddSingleton<IDataCollectionService<EventDocument>, DataCollectionService<EventDocument>>();
    }
}