using Apps.ProductWebAPI.Extensions;
using Apps.EndpointDefinitions.ProductWebAPI;
using Microsoft.EntityFrameworkCore;
using Storage.AppStorage;
using Mod.Product.Root;
using ProductWebApi.Middlewares;
using Serilog;

namespace Apps.ProductWebAPI.Helpers;

public class StartupHelper
{
    public StartupHelper(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        
        builder.Services.AddEndpointDefinitions(typeof(ProductEndpointDefinition));
            
        var startupConfigurator = new StartupConfigurator(Configuration, builder);
        startupConfigurator.Configure();
    }
    
    public async Task Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            // app.UseSwagger();
            // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",ProductWebAPI "ProductWebApi v1"));
        }

        app.UseMiddleware<ErrorHandlerMiddleware>();

        // using (var serviceScope = app.ApplicationServices?.CreateScope())
        // {
        //     var context = serviceScope?.ServiceProvider.GetRequiredService<ApiDbContext>();
        //     
        //     context?.Database.EnsureCreated();
        //     // await context?.Database?.MigrateAsync();
        // }
        //to log Requests
        app.UseSerilogRequestLogging();

        // app.UseHttpsRedirection();

        app.UseRouting();
        // app.UseAuthorization();
        ((WebApplication)app).UseEndpointDefinitions();
    }
}