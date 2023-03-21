using Data.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mod.Product.Base.Queries;
using Mod.Product.Root.Configuration;
using Serilog;
using Serilog.Sinks.GrafanaLoki;

namespace Mod.Product.Root.ExtenalServices;

public class ModProductExternalServicesConfigurator
{
    private readonly IServiceCollection _services;
    private readonly ProductEnvironmentContext _productEnvironmentContext;

    public ModProductExternalServicesConfigurator(IServiceCollection services, ProductEnvironmentContext productEnvironmentContext)
    {
        _services = services;
        _productEnvironmentContext = productEnvironmentContext;
    }

    public void Configure()
    {
        _services.AddOptions();
        _services.AddAutoMapper(typeof(GetAllProductsQuery).Assembly); 
        _services.AddMediatR(typeof(GetAllProductsQuery).Assembly);

        ConfigureDataBase();
        ConfigureLogging();
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
    }

    private void ConfigureDataBase()
    {
        _services.AddDbContext<ApiDbContext>(options =>
            options.UseNpgsql(
                _productEnvironmentContext.AppConfiguration.DbConnection
            ));
    }
}