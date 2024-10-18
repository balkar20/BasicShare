using Data.Base.Objects;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mod.Order.Base.Repositories;
using Mod.Order.EventData.Aggregates;
using Mod.Order.Interfaces;
using Mod.Order.Services;
using MongoDataServices;

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
        // _services.AddSingleton<IOrderRepository, OrderSqlRepository>();
        // _services.AddScoped<IProductRepository, ProductSqlRepository>();
        // _services.AddScoped<IProductService, ProductService>();
        _services.AddSingleton<IOrderWriteService, OrderWriteService>();
        _services.AddScoped<IOrderReadService, OrderReadService>();
        _services.AddScoped<IOrderRepository, OrderSqlRepository>();
        _services.AddSingleton<IAggregateRepository<OrderAggregate>, AggregateRepository<OrderAggregate>>();
        _services.AddSingleton<IAggregateStorage, AggregateStorage>();
        _services.AddSingleton<IMessageBusService, MessageBusService>();
        _services.AddSingleton<IDataCollectionService<EventDocument>, DataCollectionService<EventDocument>>();
    }
}