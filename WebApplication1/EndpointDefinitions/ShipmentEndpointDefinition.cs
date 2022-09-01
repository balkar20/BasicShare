using Core.RabbitMqBase.Interfaces;
using Core.RabbitMqBase.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.Shipment.Base.Commands;
using Mod.Shipment.Base.Queries;
using Mod.Shipment.Base.Repositories;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;


namespace Apps.EndpointDefinitions.BaseWebApi;

public class ShipmentEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Startup Tool Template");
        app.MapGet("api/shipments", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllShipmentsQuery()));
        app.MapPost("api/shipments",
            ([FromServices] IMediator _mediator, [FromBody] ShipmentModel Shipment) =>
                _mediator.Send(new CreateShipmentCommand(Shipment)));
        app.MapPut("api/shipments",
            ([FromServices] IMediator _mediator, [FromBody] ShipmentModel Shipment) =>
                _mediator.Send(new UpdateShipmentCommand(Shipment)));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<IRabbitMQReader, RabbitMQReader>();
        services.AddScoped<IShipmentRepository, ShipmentRepository>();
        services.AddScoped<IShipmentService, ShipmentService>();
        services.AddScoped<IRabitMQProducer, RabitMQProducer>();
    }
}