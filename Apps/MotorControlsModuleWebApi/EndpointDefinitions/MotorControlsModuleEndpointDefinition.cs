using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.MotorControlsModule.Base.Commands;
using Mod.MotorControlsModule.Base.Queries;
using Mod.MotorControlsModule.Base.Repositories;
using Mod.MotorControlsModule.Interfaces;
using Mod.MotorControlsModule.Services;
using Mod.MotorControlsModule.Models;


namespace Apps.EndpointDefinitions.MotorControlsModuleWebAPI;

public class MotorControlsModuleEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Startup Tool Template");
        app.MapGet("api/products", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllMotorControlsModulesQuery()));
        app.MapGet("api/testLogger", ([FromServices] IMediator _mediator) => _mediator.Send(new GetTempQuery()));
        app.MapPost("api/products",
            ([FromServices] IMediator _mediator, [FromBody] MotorControlsModuleModel product) =>
                _mediator.Send(new CreateMotorControlsModuleCommand(product)));
        app.MapPut("api/products",
            ([FromServices] IMediator _mediator, [FromBody] MotorControlsModuleModel product) =>
                _mediator.Send(new UpdateMotorControlsModuleCommand(product)));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IMotorControlsModuleRepository, MotorControlsModuleSqlRepository>();
        services.AddScoped<IMotorControlsModuleService, MotorControlsModuleService>();
    }
}