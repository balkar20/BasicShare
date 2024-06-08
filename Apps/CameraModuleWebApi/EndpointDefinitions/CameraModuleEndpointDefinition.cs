using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.CameraModule.Base.Commands;
using Mod.CameraModule.Base.Queries;
using Mod.CameraModule.Base.Repositories;
using Mod.CameraModule.Interfaces;
using Mod.CameraModule.Services;
using Mod.CameraModule.Models;


namespace Apps.EndpointDefinitions.CameraModuleWebAPI;

public class CameraModuleEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Startup Tool Template");
        app.MapGet("api/products", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllCameraModulesQuery()));
        app.MapGet("api/testLogger", ([FromServices] IMediator _mediator) => _mediator.Send(new GetTempQuery()));
        app.MapPost("api/products",
            ([FromServices] IMediator _mediator, [FromBody] CameraModuleModel product) =>
                _mediator.Send(new CreateCameraModuleCommand(product)));
        app.MapPut("api/products",
            ([FromServices] IMediator _mediator, [FromBody] CameraModuleModel product) =>
                _mediator.Send(new UpdateCameraModuleCommand(product)));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<ICameraModuleRepository, CameraModuleSqlRepository>();
        services.AddScoped<ICameraModuleService, CameraModuleService>();
    }
}