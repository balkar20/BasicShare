
using Apps.Blazor.Identity.IdentityProvider.Server.EndpointDefinitions;
using Apps.Blazor.Identity.IdentityProvider.Server.Extensions;
using Blazored.LocalStorage;
using Core.Auh.Configuration;
using Core.Auh.Entities;
using Data.IdentityDb;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mod.Auth.Base.Queries;
using Mod.Auth.Base.Repositories;
using Mod.Auth.Interfaces;
using Mod.Auth.Services;
using Serilog;
using System.Text;
using Apps.Blazor.Identity.IdentityProvider.Server.Middlewares;
using Core.Base.Custom;
using IdentityProvider.Server.Hubs;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Mod.Auth.Root;
using Mod.Order.Base.Commands;
using Mod.Order.Base.Repositories;
using Mod.Order.Interfaces;
// using IdentityProvider.Client;
using Serilog.Sinks.GrafanaLoki;

namespace Apps.Blazor.Identity.IdentityProvider.Server.Helpers;

public static class StartupHelper
{
    private static string str;
    public static void Configure(WebApplication app)
    {
        app.UseEndpointDefinitions();
        app.UseMiddleware<ErrorHandlerMiddleware>();
        
        using (var serviceScope = app.Services?.CreateScope())
        {
            var context = serviceScope?.ServiceProvider.GetRequiredService<ApplicationContext>();
            context?.Database.EnsureCreated();
        }
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();
        app.MapBlazorHub();
        app.MapHub<ChatHub>("/chathub");


        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.UseAuthentication();
        app.UseAuthorization();

        //SeedDataService.Initialize(app.Services);
        app.Run();
    }
    
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        // var credentials = new GrafanaLokiCredentials()
        // {
        //     User = "admin",
        //     Password = "admin"
        // };
        //Creating the Logger with Minimum Settings
        // Log.Logger = new LoggerConfiguration()
        //     .MinimumLevel.Verbose()
        //     .Enrich.FromLogContext()
        //     .Enrich.WithProperty("ALabel", "ALabelValue")
        //     .WriteTo.File("log.txt", rollingInterval: RollingInterval.Hour)
        //     .WriteTo.GrafanaLoki(
        //         "http://localhost:3100",
        //         credentials,
        //         new Dictionary<string, string>() { { "app", "Serilog.Sinks.GrafanaLoki.IdentityProvider.Server" } }, // Global labels
        //         Serilog.Events.LogEventLevel.Debug,
        //         httpClient: new CustomHttpClient() 
        //     )
        //     .CreateLogger();
        
        // var configuration = builder.Configuration;
        // var services = builder.Services;
        
        // services.AddServerSideBlazor();
        // builder.Services.AddResponseCompression(opts =>
        // {
        //     opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        //         new[] { "application/octet-stream" });
        // });
        //
        // builder.Logging.AddSerilog(Log.Logger);
        // builder.Host.UseSerilog(Log.Logger);
        //
        // var authConfiguration = configuration.GetSection(AuthConfiguration.HostConfiguration);
        // services.Configure<AuthConfiguration>(
        //     authConfiguration);
        // services.AddDbContext<DbContext, ApplicationContext>(options =>
        // {
        //     options.UseNpgsql(configuration.GetConnectionString("sqlConnection"));
        // });
    
    //     services.AddIdentity<UserEntity, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    // .AddEntityFrameworkStores<ApplicationContext>();
    //     services.AddAuthentication(opt =>
    //     {
    //         opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //         opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //     }).AddJwtBearer(options =>
    //     {
    //         options.TokenValidationParameters = new TokenValidationParameters
    //         {
    //             ValidateIssuer = true,
    //             ValidateAudience = true,
    //             ValidateLifetime = true,
    //             ValidateIssuerSigningKey = true,
    //             ValidIssuer = authConfiguration["ValidIssuer"],
    //             ValidAudience = authConfiguration["ValidAudience"],
    //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfiguration["SecurityKey"]))
    //         };
    //     });

        // builder.Services.AddStackExchangeRedisCache(options =>
        // {
        //     options.Configuration = builder.Configuration.GetValue<string>("RedisCacheUrl");
        // });
        //
        // builder.Services.AddBlazoredLocalStorage();
        // builder.Services.AddAuthorizationCore(opts =>
        // {
        //     opts.AddPolicy("OnlyDeliveryStaffCoordinator", policy => {
        //         policy.RequireClaim("DeliveryStaff", "Coordinator");
        //     });
        // });
        //
        // services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
        // builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //
        // // services.AddScoped<IAuthRepository, AuthRepository>();
        //
        // services.AddScoped<IRabbitMqProducer, RabbitMqProducer>();
        // // services.AddScoped<IOrderRepository, OrderRepository>();
        // services.AddScoped<IAuthService, AuthService>();
        //
        // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
        //
        //
        // services.AddControllersWithViews();
        // services.AddRazorPages();
        // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddEndpointDefinitions(typeof(AuthEndpointDefinition));
        var startupConfigurator = new StartupConfigurator(builder.Configuration, builder);
        startupConfigurator.Configure();
        // services.AddMediatR(typeof(GetAllUsersQuery).Assembly);
        // services.AddMediatR(typeof(CreateOrderCommand).Assembly);
    }
    
}