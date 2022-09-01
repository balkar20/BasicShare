using Microsoft.OpenApi.Models;

// namespace Apps.EndpointDefinitions.BaseWebApi;

// public class SwaggerV2EndpointDefinition : IEndpointDefinition
// {
//     public void DefineServices(IServiceCollection services)
//     {
//         services.AddSwaggerGen(c =>
//         {
//             services.AddEndpointsApiExplorer();
//             c.SwaggerDoc("v2", new OpenApiInfo() { Title = "ShipmentApp", Version = "v2" });
//         });
//     }
//
//     public void DefineEndpoints(WebApplication app)
//     {
//         app.UseSwagger();
//         app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "ShipmentApp"));
//     }
// }