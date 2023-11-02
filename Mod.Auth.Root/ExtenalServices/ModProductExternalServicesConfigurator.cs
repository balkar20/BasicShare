using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Blazored.LocalStorage;
using Core.Auh.Entities;
using Data.IdentityDb;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Mod.Auth.Base.Handlers;
using Mod.Auth.Base.Queries;
using Mod.Auth.Root.Configuration;
using Mod.Auth.Services;
using Serilog;
using Serilog.Sinks.GrafanaLoki;

namespace Mod.Auth.Root.ExtenalServices;

public class ModAuthExternalServicesConfigurator
{
    private readonly IServiceCollection _services;
    private readonly WebApplicationBuilder _builder;
    private readonly AuthEnvironmentContext _authEnvironmentContext;

    public ModAuthExternalServicesConfigurator(AuthEnvironmentContext authEnvironmentContext, WebApplicationBuilder builder)
    {
        _services = builder.Services;
        _authEnvironmentContext = authEnvironmentContext;
        _builder = builder;
    }

    public void Configure()
    {
        _services.AddBlazoredLocalStorage();
        _services.AddAuthorizationCore(opts =>
        {
            opts.AddPolicy("OnlyDeliveryStaffCoordinator", policy => {
                policy.RequireClaim("DeliveryStaff", "Coordinator");
            });
        });
        _services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
        _services.AddServerSideBlazor();
        _services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "application/octet-stream" });
        });
        _services.AddOptions();
        _services.AddGrpc();
        _services.AddControllersWithViews();
        _services.AddRazorPages();
        _services.AddAutoMapper(typeof(RegisterCommandHandler).Assembly);
        _services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllUsersQuery).Assembly));

        ConfigureDataBase();
        ConfigureLocalization();
        ConfigureAuthentication();
        ConfigureLogging();
    }

    private void ConfigureDataBase()
    {
        
        _services.AddDbContext<DbContext, ApplicationContext>(options =>
        {
            options.UseNpgsql(_authEnvironmentContext.AppConfiguration.DbConnection);
        });
        _services.AddIdentity<UserEntity, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationContext>();
    }

    private void ConfigureAuthentication()
    {
        _services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _authEnvironmentContext.AuthConfiguration.ValidIssuer,
                ValidAudience = _authEnvironmentContext.AuthConfiguration.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authEnvironmentContext.AuthConfiguration.SecurityKey))
            };
        });
    }

    private void ConfigureCache()
    {
        _services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = _authEnvironmentContext.AppConfiguration.RedisUrl;
        });
    }

    private void ConfigureLocalization()
    {
        _services.AddSingleton(new ResourceManager("Mod.Auth.Base.Resources.Handlers.RegisterCommandHandler",
            typeof(RegisterCommandHandler).GetTypeInfo().Assembly));
        _services.AddSingleton(new ResourceManager("Mod.Auth.Base.Resources.Handlers.GetAllAuthsQueryHandler",
            typeof(RegisterCommandHandler).GetTypeInfo().Assembly));
        _services.AddLocalization(op => op.ResourcesPath = "Resources");
    }

    private void ConfigureLogging()
    {
        var credentials = new GrafanaLokiCredentials()
        {
            User = "admin",
            Password = "admin"
        };
        //Creating the Logger with Minimum Settings
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .Enrich.WithProperty("ALabel2", "ALabelValue2")
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Minute)
            .WriteTo.GrafanaLoki(
                "http://localhost:3100",
                credentials,
                new Dictionary<string, string>() { { "api", "Serilog.Sinks.GrafanaLoki.IdentityProvider.Server" } }, // Global labels
                Serilog.Events.LogEventLevel.Debug
            )
            .CreateLogger();

        _builder.Logging.AddSerilog(Log.Logger);
        _builder.Host.UseSerilog(Log.Logger);
    }
}