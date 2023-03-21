using Apps.ProductWebAPI.Extensions;
using Apps.EndpointDefinitions.ProductWebAPI;
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
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEndpointDefinitions(typeof(ProductEndpointDefinition));
            
        var startupConfigurator = new StartupConfigurator(Configuration, services);
        startupConfigurator.Configure();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            // app.UseSwagger();
            // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",ProductWebAPI "ProductWebApi v1"));
        }

        app.UseMiddleware<ErrorHandlerMiddleware>();
        //to log Requests
        app.UseSerilogRequestLogging();

        // app.UseHttpsRedirection();

        app.UseRouting();
        // app.UseAuthorization();
        ((WebApplication)app).UseEndpointDefinitions();
    }
}