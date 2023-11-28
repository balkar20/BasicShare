using System.Reflection;
using Storage.AppStorage;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mod.Product.Base.Queries;
using Mod.Product.Root.Configuration;
using Mod.Product.Services.Consumers;
using Serilog;
using Serilog.Sinks.GrafanaLoki;

namespace Mod.Product.Root.ExtenalServices;

public class ModProductExternalServicesConfigurator
{
    private readonly IServiceCollection _services;
    private readonly ProductEnvironmentContext _productEnvironmentContext;
    private readonly WebApplicationBuilder _builder;

    public ModProductExternalServicesConfigurator(WebApplicationBuilder builder, ProductEnvironmentContext productEnvironmentContext)
    {
        _services = builder.Services;
        _productEnvironmentContext = productEnvironmentContext;
        _builder = builder;
    }

    public void Configure()
    {
        _services.AddOptions();
        _services.AddAutoMapper(typeof(GetAllProductsQuery).Assembly); 
        // _services.AddMediatR(typeof(GetAllProductsQuery).Assembly);
        _services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQuery).Assembly));

        ConfigureDataBase();
        ConfigureLogging();
        ConfigureListeners();
        ConfigureMessaging();
    }

    private void ConfigureMessaging()
    {
        _services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
           
            x.SetInMemorySagaRepositoryProvider();

            var entryAssembly = Assembly.GetEntryAssembly();
            x.AddSagaStateMachines(entryAssembly);
            x.AddSagas(entryAssembly);
            x.AddActivities(entryAssembly);

            x.AddConsumers(typeof(OrderCreationConsumer).Assembly);
            
            x.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("localhost",h =>
                {
                    h.Password("guest");
                    h.Username("guest");
                });

                // configurator.ReceiveEndpoint("ordering", endpointConfigurator =>
                // {
                //     endpointConfigurator.Lazy = true;
                //     endpointConfigurator.PrefetchCount = 20;
                // });
               
                configurator.ConfigureEndpoints(context);
            });
        });
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
                new Dictionary<string, string>() { { "app", "Serilog.Sinks.GrafanaLoki.ProductWebApi" } }, // Global labels
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
                _productEnvironmentContext.AppConfiguration.DbConnection
            ));
    }

    private void ConfigureListeners()
    {
        // _services.AddHostedService<OrderCreationListener>();
    }
}