namespace WebApplication1;

// public class SwaggerEndpointDefinition: IEndpointDefinition
// {
//     public void DefineServices(IServiceCollection services)
//     {
//         services.AddSwaggerGen(c =>
//         {
//             services.AddEndpointsApiExplorer();
//             c.SwaggerDoc("v1", new OpenApiInfo() { Title = "WebApplication1", Version = "v1" });
//         });
//     }
//
//     public void DefineEndpoints(WebApplication app)
//     {
//         app.UseSwagger();
//         app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1"));
//     }
// }