using Apps.ProductWebAPI.Extensions;
using Apps.ProductWebAPI.Middlewares;
using Apps.EndpointDefinitions.ProductWebAPI;
using Core.Auh.Configuration;
using Core.Auh.Entities;
using Core.Base.Configuration;
using Data.IdentityDb;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mod.Auth.Base.Queries;
using Serilog;
using Serilog.Sinks.Grafana.Loki;

namespace Apps.ProductWebAPI.Helpers;

public static class StartupHelper
{
    public static void ConfigureServices(WebApplication app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseAuthentication();
        app.UseEndpointDefinitions();
        app.Run();
    }
    
    public static void Configure(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("AuthDb");
        //builder.Services.AddIdentityCore<UserEntity>();
        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(
                connectionString
            ));

        //    builder.Services.AddIdentity<UserEntity, IdentityRole>()
        //.AddEntityFrameworkStores<ApplicationContext>();
        var idBuilder = builder.Services.AddIdentityCore<UserEntity>();
        var identityBuilder = new IdentityBuilder(idBuilder.UserType, idBuilder.Services);
        identityBuilder.AddEntityFrameworkStores<ApplicationContext>();
        identityBuilder.AddSignInManager<SignInManager<UserEntity>>();

        builder.Services.AddEndpointsApiExplorer();
        

        builder.Services.Configure<AuthConfiguration>(
            builder.Configuration.GetSection(AuthConfiguration.HostConfiguration));
        builder.Services.AddOptions<AppConfiguration>().Configure(configuration => 
            configuration = new AppConfiguration(builder.Configuration.GetValue<string>)
        );

        AuthConfiguration productApiConfiguration = builder.Configuration.GetSection(AuthConfiguration.HostConfiguration).Get<AuthConfiguration>();
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
        builder.Services.AddMediatR(typeof(GetAllAuthsQuery).Assembly);


        
        builder.Services.AddEndpointDefinitions(typeof(AuthEndpointDefinition));
        // builder.Services.AddEndpointDefinitions(typeof(OrderEndpointDefinition));
        builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .WriteTo.GrafanaLoki("http://localhost:3100"));
    }
}