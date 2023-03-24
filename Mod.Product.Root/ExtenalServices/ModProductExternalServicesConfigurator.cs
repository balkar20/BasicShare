using Data.Db;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mod.Product.Base.Queries;
using Mod.Product.Root.AppServices;
using Mod.Product.Root.Configuration;
using Mod.Product.Services.Listeners;
using Serilog;
using Serilog.Core;
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
        _services.AddMediatR(typeof(GetAllProductsQuery).Assembly);
        
        

        ConfigureDataBase();
        ConfigureLogging();
        ConfigureListeners();
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
        _services.AddHostedService<OrderCreationListener>();
    }
}