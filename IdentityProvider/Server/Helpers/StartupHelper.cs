
using Apps.Blazor.Identity.IdentityProvider.Server.EndpointDefinitions;
using Apps.Blazor.Identity.IdentityProvider.Server.Extensions;
using Core.Auh.Configuration;
using Core.Auh.Entities;
using Core.Base.Configuration;
using Data.IdentityDb;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mod.Auth.Base.Queries;
using Mod.Auth.Base.Repositories;
using Mod.Auth.Interfaces;
using Mod.Auth.Services;
using Serilog;
using System.Text;

namespace Apps.Blazor.Identity.IdentityProvider.Server.Helpers;

public static class StartupHelper
{
    public static void ConfigureServices(WebApplication app)
    {
        //app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseEndpointDefinitions();
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

        app.Run();


        app.UseAuthentication();
        app.UseAuthorization();
        app.Run();
    }
    
    public static void Configure(WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;

        var authConfiguration = configuration.GetSection(AuthConfiguration.HostConfiguration);
        services.Configure<AuthConfiguration>(
            authConfiguration);
        services.AddDbContext<ApplicationContext>(options =>
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

        //services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddControllersWithViews();
        services.AddRazorPages();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddEndpointDefinitions(typeof(AuthEndpointDefinition));

        services.AddMediatR(typeof(GetAllAuthsQuery).Assembly);
        builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341"));


    }
}