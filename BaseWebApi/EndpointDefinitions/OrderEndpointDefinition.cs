using Core.RabbitMqBase.Interfaces;
using Core.RabbitMqBase.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mod.Order.Base.Commands;
using Mod.Order.Base.Queries;
using Mod.Order.Base.Repositories;
using Mod.Order.Interfaces;
using Mod.Order.Models;

namespace Apps.BaseWebApi;

public class OrderEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/", () => "Startup Tool Template");
        app.MapGet("api/Orders", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllOrdersQuery()));
        app.MapPost("api/Orders",
            ([FromServices] IMediator _mediator, [FromBody] OrderModel Order) =>
                _mediator.Send(new CreateOrderCommand(Order)));
        app.MapPut("api/Orders",
            ([FromServices] IMediator _mediator, [FromBody] OrderModel Order) =>
                _mediator.Send(new UpdateOrderCommand(Order)));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IRabitMQProducer, RabitMQProducer>();
    }
}