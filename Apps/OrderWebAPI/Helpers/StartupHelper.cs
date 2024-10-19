using System.Text.Json.Serialization;
using Apps.OrderWebAPI.Extensions;
using Apps.EndpointDefinitions.OrderWebAPI;
using Storage.AppStorage;
using Mod.Order.Root;
using OrderWebApi.Middlewares;
using Serilog;

namespace Apps.OrderWebAPI.Helpers;

public class StartupHelper
{
    public StartupHelper(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        // Configure JSON options to handle enums and other serialization settings
        builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
        {
            options.SerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            options.SerializerOptions.PropertyNamingPolicy = null; // To preserve property names as defined in the model
        });
        builder.Services.AddEndpointDefinitions(typeof(OrderEndpointDefinition));

        var startupConfigurator = new StartupConfigurator(Configuration, builder);
        startupConfigurator.Configure();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            // app.UseSwagger();
            // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",OrderWebAPI "OrderWebApi v1"));
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