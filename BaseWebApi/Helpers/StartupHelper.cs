using Apps.BaseWebApi.Extensions;
using Apps.BaseWebApi.Middlewares;
using Apps.EndpointDefinitions.BaseWebApi;
using Core.Base.Configuration;
using Data.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mod.Order.Base.Queries;
using Mod.Product.Base.Queries;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Grafana.Loki;
using Serilog.AspNetCore;

namespace Apps.BaseWebApi.Helpers;

public static class StartupHelper
{
    public static void ConfigureServices(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseSerilogRequestLogging();
        
        app.UseMiddleware<ErrorHandlerMiddleware>();
        
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
        // builder.UseSe;

        builder.Services.Configure<ProductApiConfiguration>(
            builder.Configuration.GetSection(ProductApiConfiguration.AuthConfiguration));
        builder.Services.Configure<AppConfiguration>(
            builder.Configuration.GetSection(AppConfiguration.HostConfiguration));

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
        builder.Services.AddMediatR(typeof(GetAllProductsQuery).Assembly);
        // builder.Services.AddMediatR(typeof(GetAllOrdersQuery).Assembly);
        
        builder.Services.AddEndpointDefinitions(typeof(ProductEndpointDefinition));
        // builder.Services.AddEndpointDefinitions(typeof(OrderEndpointDefinition));
        var credentials = new LokiCredentials()
        {
            Login = "admin",
            Password = "admin"
        };

        
        builder.Host.UseSerilog((ctx, cfg) =>
        {
            //Override Few of the Configurations
            cfg.Enrich.WithProperty("Application", ctx.HostingEnvironment.ApplicationName)
                .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName)
                .WriteTo.Console(new RenderedCompactJsonFormatter());
        });
        // builder.Services.UseSerilogRequestLogging();
    }
}