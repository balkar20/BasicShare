// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.OpenApi.Models;
//
// namespace Apps.EndpointDefinitions.PowerSupplyWebAPI;
//
// public class SwaggerEndpointDefinition: IEndpointDefinition
// {
//     public void DefineServices(IServiceCollection services)
//     {
//         services.AddSwaggerGen(c =>
//         {
//             services.AddEndpointsApiExplorer();
//             c.SwaggerDoc("v1", new OpenApiInfo() { Title = "PowerSupplyWebAPI", Version = "v1" });
//         });
//     }
//
//     public void DefineEndpoints(WebApplication app)
//     {
//         app.UseSwagger();
//         app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PowerSupplyWebAPI"));
//     }
// }