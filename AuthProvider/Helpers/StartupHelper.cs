using Apps.BaseWebApi.Extensions;
using Apps.BaseWebApi.Middlewares;
using Apps.EndpointDefinitions.BaseWebApi;
using Core.Auh.Configuration;
using Core.Auh.Entities;
using Core.Base.Configuration;
using Data.Db;
using Data.IdentityDb;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mod.Auth.Base.Queries;
using Serilog;

namespace Apps.BaseWebApi.Helpers;

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
        builder.Services.AddDbContext<ApiDbContext>(options =>
            options.UseNpgsql(
                connectionString
            ));

        //    builder.Services.AddIdentity<UserEntity, IdentityRole>()
        //.AddEntityFrameworkStores<ApplicationContext>();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.Configure<AuthConfiguration>(
            builder.Configuration.GetSection(AuthConfiguration.HostConfiguration));
        builder.Services.Configure<AppConfiguration>(
            builder.Configuration.GetSection(AppConfiguration.HostConfiguration));

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
            .WriteTo.Seq("http://localhost:5341"));
    }
}