
using Apps.Blazor.Identity.IdentityProvider.Server.Extensions;
using Data.IdentityDb;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Apps.Blazor.Identity.IdentityProvider.Server.Helpers;

public static class StartupHelper
{
    public static void ConfigureServices(WebApplication app)
    {
        //app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseEndpointDefinitions();

        app.UseAuthentication();
        app.UseAuthorization();
        app.Run();
    }
    
    public static void Configure(WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;
        services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();
        var jwtSettings = configuration.GetSection("JWTSettings");
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

                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]))
            };
        });
        services.AddControllers();
    }
}