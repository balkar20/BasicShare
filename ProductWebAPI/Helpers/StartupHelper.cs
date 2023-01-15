// using System;
// using Apps.BaseWebApi.Extensions;
// using Apps.BaseWebApi.Middlewares;
// using Apps.EndpointDefinitions.BaseWebApi;
// using Core.Base.Configuration;
// using Core.Base.Utilities;
// using Data.Db;
// using MediatR;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Mod.Order.Base.Queries;
// using Mod.Product.Base.Queries;
// using Serilog;
// using Serilog.Formatting.Compact;
// using Serilog.Sinks.Grafana.Loki;
// using Serilog.AspNetCore;
// using StackExchange.Redis;
// using ILogger = Serilog.ILogger;
//
// namespace Apps.BaseWebApi.Helpers;
//
// public static class StartupHelper
// {
//     private static string redisConnection;
//     public static void ConfigureServices(WebApplication app)
//     {
//         app.UseSwagger();
//         app.UseSwaggerUI();
//         
//         app.UseSerilogRequestLogging();
//         
//         app.UseMiddleware<ErrorHandlerMiddleware>();
//         
//         app.UseEndpointDefinitions();
//         
//         Log.Logger = new LoggerConfiguration()
//             .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
//             .Enrich.FromLogContext()
//             .WriteTo.Console()
//             .CreateLogger();
//         using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
//         {
//             var context = serviceScope?.ServiceProvider.GetRequiredService<ApiDbContext>();
//             context?.Database.EnsureCreated();
//         }
//
//         using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
//         {
//             var logger = serviceScope?.ServiceProvider.GetRequiredService<ILogger>();
//             logger?.Debug("redisConnectionString");
//             logger?.Debug(redisConnection);
//         }
//         app.Run();
//     }
//     
//     public static void Configure(WebApplicationBuilder builder)
//     {
//         var dockerDbHost = Environment.GetEnvironmentVariable("DOCKER_DB_Host");
//         var connectionStringKey = string.IsNullOrWhiteSpace(dockerDbHost) ? "ProductDb" : "ProductDbForDocker";
//         var connectionString = builder.Configuration.GetConnectionString(connectionStringKey);
//         builder.Services.AddDbContext<ApiDbContext>(options =>
//             options.UseNpgsql(
//                 connectionString
//             ));
//
//         builder.Services.AddEndpointsApiExplorer();
//         builder.Services.AddSwaggerGen();
//         // builder.UseSe;
//
//         builder.Services.Configure<ProductApiConfiguration>(
//             builder.Configuration.GetSection(ProductApiConfiguration.AuthConfiguration));
//         builder.Services.Configure<AppConfiguration>(
//             builder.Configuration.GetSection(AppConfiguration.HostConfiguration));
//
//         ProductApiConfiguration productApiConfiguration = builder.Configuration.GetSection(ProductApiConfiguration.AuthConfiguration).Get<ProductApiConfiguration>();
//         // builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//         //     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
//         //     {
//         //         options.Authority = productApiConfiguration.IdentityServerBaseUrl;
//         //         options.RequireHttpsMetadata = productApiConfiguration.RequireHttpsMetadata;
//         //         options.Audience = productApiConfiguration.OidcApiName;
//         //     });
//
//
//         redisConnection = Environment.GetEnvironmentVariable("REDIS_CONNECTION");
//
//         LogBufferDataUtility.RedisConnectionStringFromJsonConfig = redisConnection;
//
//         builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
//         builder.Services.AddMediatR(typeof(GetAllProductsQuery).Assembly);
//
//         builder.Services.AddEndpointDefinitions(typeof(ProductEndpointDefinition));
//         // builder.Services.AddEndpointDefinitions(typeof(OrderEndpointDefinition));
//         var credentials = new LokiCredentials()
//         {
//             Login = "admin",
//             Password = "admin"
//         };
//
//         var lokiConnrctionUrl = Environment.GetEnvironmentVariable("loki");
//         if(lokiConnrctionUrl is null )
//             lokiConnrctionUrl = builder.Configuration.GetValue<string>("LokiUrl");
//         
//         builder.Host.UseSerilog((ctx, cfg) =>
//         {
//             //Override Few of the Configurations
//             cfg.Enrich.WithProperty("Application", ctx.HostingEnvironment.ApplicationName)
//                 .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName)
//                 .WriteTo.Console(new RenderedCompactJsonFormatter())
//                 .WriteTo.GrafanaLoki("http://loki:3100");
//         });
//         
//         // builder.Services.UseSerilogRequestLogging();
//     }
// }