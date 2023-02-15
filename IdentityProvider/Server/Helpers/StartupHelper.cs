
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
// using IdentityProvider.Client;
using Serilog.Sinks.GrafanaLoki;

namespace Apps.Blazor.Identity.IdentityProvider.Server.Helpers;

public static class StartupHelper
{
    private static string str;
    public static void Configure(WebApplication app)
    {
        //app.UseMiddleware<ErrorHandlerMiddleware>();
        
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
        var credentials = new GrafanaLokiCredentials()
        {
            User = "admin",
            Password = "admin"
        };
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
        var configuration = builder.Configuration;
        var services = builder.Services;
        
        services.AddServerSideBlazor();

        builder.Logging.AddSerilog(Log.Logger);
        builder.Host.UseSerilog(Log.Logger);

        var authConfiguration = configuration.GetSection(AuthConfiguration.HostConfiguration);
        services.Configure<AuthConfiguration>(
            authConfiguration);
        services.AddDbContext<DbContext, ApplicationContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("sqlConnection")));
        services.AddIdentity<UserEntity, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationContext>();
        services.AddAuthentication(opt =>
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
                ValidIssuer = authConfiguration["ValidIssuer"],
                ValidAudience = authConfiguration["ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfiguration["SecurityKey"]))
            };
        });

        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetValue<string>("RedisCacheUrl");
        });

        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddAuthorizationCore(opts =>
        {
            opts.AddPolicy("OnlyDeliveryStaffCoordinator", policy => {
                policy.RequireClaim("DeliveryStaff", "Coordinator");
            });
        });

        services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
        //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        //services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 

       
        services.AddControllersWithViews();
        services.AddRazorPages();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddEndpointDefinitions(typeof(AuthEndpointDefinition));

        services.AddMediatR(typeof(GetAllAuthsQuery).Assembly);
    }
    
}

public class CustomHttpClient : GrafanaLokiHttpClient
{
    public override async Task<HttpResponseMessage> PostAsync(string requestUri, Stream contentStream)
    {
        using var content = new StreamContent(contentStream);
        content.Headers.Add("Content-Type", "application/json");
        var response = await HttpClient
            .PostAsync(requestUri, content)
            .ConfigureAwait(false);
        return response;
    }
}