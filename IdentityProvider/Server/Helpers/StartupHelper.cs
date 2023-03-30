using Apps.Blazor.Identity.IdentityProvider.Server.EndpointDefinitions;
using Apps.Blazor.Identity.IdentityProvider.Server.Extensions;
using Data.IdentityDb;
using Apps.Blazor.Identity.IdentityProvider.Server.Middlewares;
using IdentityProvider.Server.Hubs;
using Mod.Auth.Root;

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

        app.Run();
    }

    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointDefinitions(typeof(AuthEndpointDefinition));
        var startupConfigurator = new StartupConfigurator(builder.Configuration, builder);
        startupConfigurator.Configure();
    }
}