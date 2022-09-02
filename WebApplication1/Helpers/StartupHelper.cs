using Apps.BaseWebApi.Extensions;
using Apps.BaseWebApi.Middlewares;
using Apps.EndpointDefinitions.BaseWebApi;
using Core.Base.Configuration;
using Data.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mod.Shipment.Base.Queries;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Grafana.Loki;
using Serilog.Sinks.Loki;

namespace Apps.BaseWebApi.Helpers;

public static class StartupHelper
{
    public static void ConfigureServices(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseSerilogRequestLogging();
        app.UseEndpointDefinitions();
        app.Run();
    }
    
    public static void Configure(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("ProductDb");
        builder.Services.AddDbContext<ApiDbContext>(options =>
            options.UseNpgsql(
                connectionString
            ));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<ProductApiConfiguration>(
            builder.Configuration.GetSection(ProductApiConfiguration.AuthConfiguration));
        builder.Services.Configure<AppConfiguration>(
            builder.Configuration.GetSection(AppConfiguration.HostConfiguration));
        builder.Services.Configure<MessageBrokerConfiguration>(
            builder.Configuration.GetSection(MessageBrokerConfiguration.HostConfiguration));

        ProductApiConfiguration productApiConfiguration = builder.Configuration.GetSection(ProductApiConfiguration.AuthConfiguration).Get<ProductApiConfiguration>();
        // builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        //     {
        //         options.Authority = productApiConfiguration.IdentityServerBaseUrl;
        //         options.RequireHttpsMetadata = productApiConfiguration.RequireHttpsMetadata;
        //         options.Audience = productApiConfiguration.OidcApiName;
        //     });


        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetValue<string>("RedisCacheUrl");
        });

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
        builder.Services.AddMediatR(typeof(GetAllShipmentsQuery).Assembly);
        
        builder.Services.AddEndpointDefinitions(typeof(ShipmentEndpointDefinition));
        // builder.Services.AddEndpointDefinitions(typeof(OrderEndpointDefinition));?????
        //

        // Log.Logger = new LoggerConfiguration()
        //     .WriteTo.Console()
        //     .WriteTo.File("logs/log.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information, rollingInterval: RollingInterval.Day)
        //     .WriteTo.File("logs/errorlog.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)
        //     .WriteTo.Seq("http://localhost:5341")
        //     .CreateLogger();
        builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information, rollingInterval: RollingInterval.Day)
            .WriteTo.File("logs/errorlog.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)
            .WriteTo.Seq("http://localhost:5341"));
        // builder.Host.UseSerilog((ctx, lc) =>
        // {
        //     var credentials = new NoAuthCredentials(ctx.Configuration.GetConnectionString("loki"));
        //
        //     lc.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        //         .Enrich.FromLogContext()
        //         .Enrich.WithProperty("Application", ctx.HostingEnvironment.ApplicationName)
        //         .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName)
        //         .WriteTo.LokiHttp(credentials);
        //
        //     if (ctx.HostingEnvironment.IsDevelopment())
        //         lc.WriteTo.Console(new RenderedCompactJsonFormatter());
        // });
    }
}