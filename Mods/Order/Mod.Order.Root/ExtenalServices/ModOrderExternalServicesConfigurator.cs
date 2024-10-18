using System.Formats.Tar;
using System.Reflection;
using Data.Base.Objects;
using EventBus.Constants;
using Storage.AppStorage;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.MassTransit;
using Infrastructure.Services.MassTransit;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mod.Order.Base.Queries;
using Mod.Order.Root.AppServices;
using Mod.Order.Root.Configuration;
using Mod.Order.Services.Listeners;
using MongoDataServices;
using MongoObjects;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.GrafanaLoki;
using OpenSleigh.DependencyInjection;
using OpenSleigh.InMemory;
using OpenSleighGeneral.States;
using penSleighGeneral.States;

namespace Mod.Order.Root.ExtenalServices;

public class ModOrderExternalServicesConfigurator
{
    private readonly IServiceCollection _services;
    private readonly OrderEnvironmentContext _OrderEnvironmentContext;
    private readonly WebApplicationBuilder _builder;

    public ModOrderExternalServicesConfigurator(WebApplicationBuilder builder,
        OrderEnvironmentContext OrderEnvironmentContext)
    {
        _services = builder.Services;
        _OrderEnvironmentContext = OrderEnvironmentContext;
        _builder = builder;
    }

    public void Configure()
    {
        _services.AddOptions();
        _services.AddAutoMapper(typeof(GetAllOrdersQuery).Assembly);
        // _services.AddMediatR(typeof(GetAllOrdersQuery).Assembly);
        _services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllOrdersQuery).Assembly));

        ConfigureDataBase();
        ConfigureLogging();
        ConfigureListeners();
        ConfigureMessaging();
    }

    private void ConfigureMessaging()
    {
        ///1.OpenSleigh saga vs MassTransit saga
        // _services.AddOpenSleigh(cfg =>
        // {
        //     cfg.UseInMemoryTransport()
        //        .UseInMemoryPersistence()
        //        .AddSaga<SagaWithoutState>()
        //        .AddSaga<SagaWithState, MySagaState>();
        // });
        
        _services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            x.SetInMemorySagaRepositoryProvider();

            var entryAssembly = Assembly.GetEntryAssembly();
            x.AddSagaStateMachines(entryAssembly);
            x.AddSagas(entryAssembly);
            x.AddActivities(entryAssembly); 
            x.AddConsumer<OrderCreationConsumer>();
            // x.AddConsumers(typeof(OrderCreationConsumer).Assembly);
            
            x.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("localhost", h =>
                {
                    h.Password("guest");
                    h.Username("guest");
                });
                
                configurator.ConfigureEndpoints(context);
                // configurator.ReceiveEndpoint(QueuesConsts.CreateOrderMessageQueueName, e =>
                // {
                //     e.ConfigureConsumer<OrderCreationConsumer>(context);
                // });
            });
        });
        _services.AddScoped<IMassTransitService, MassTransitService>();
    }

    public void ConfigureLogging()
    {
        var credentials = new GrafanaLokiCredentials()
        {
            User = "admin",
            Password = "admin"
        };

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .Enrich.WithProperty("ALabel", "ALabelValue")
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Hour)
            .WriteTo.GrafanaLoki(
                "http://localhost:3100",
                credentials,
                new Dictionary<string, string>()
                    { { "app", "Serilog.Sinks.GrafanaLoki.OrderWebApi" } }, // Global labels
                Serilog.Events.LogEventLevel.Debug
            )
            .CreateLogger();

        _builder.Logging.AddSerilog(Log.Logger);
        _builder.Host.UseSerilog(Log.Logger);
    }

    private void ConfigureDataBase()
    {
        _services.AddDbContext<ApiDbContext>(options =>
            options.UseNpgsql(
                _OrderEnvironmentContext.AppConfiguration.DbConnection
            ));
        _services.AddSingleton<IDataCollectionService<EventDocument>, DataCollectionService<EventDocument>>();
    }

    private void ConfigureListeners()
    {
        // _services.AddHostedService<OrderEventCreationListener>();
    }
}