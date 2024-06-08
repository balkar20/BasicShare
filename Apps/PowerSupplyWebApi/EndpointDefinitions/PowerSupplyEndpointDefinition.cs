using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.PowerSupply.Base.Commands;
using Mod.PowerSupply.Base.Queries;
using Mod.PowerSupply.Base.Repositories;
using Mod.PowerSupply.Interfaces;
using Mod.PowerSupply.Services;
using Mod.PowerSupply.Models;


namespace Apps.EndpointDefinitions.PowerSupplyWebAPI;

public class PowerSupplyEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Startup Tool Template");
        app.MapGet("api/products", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllPowerSupplysQuery()));
        app.MapGet("api/testLogger", ([FromServices] IMediator _mediator) => _mediator.Send(new GetTempQuery()));
        app.MapPost("api/products",
            ([FromServices] IMediator _mediator, [FromBody] PowerSupplyModel product) =>
                _mediator.Send(new CreatePowerSupplyCommand(product)));
        app.MapPut("api/products",
            ([FromServices] IMediator _mediator, [FromBody] PowerSupplyModel product) =>
                _mediator.Send(new UpdatePowerSupplyCommand(product)));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IPowerSupplyRepository, PowerSupplySqlRepository>();
        services.AddScoped<IPowerSupplyService, PowerSupplyService>();
    }
}