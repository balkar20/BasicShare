using Infrastructure.Interfaces;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Mod.Order.Base.Commands;
using Mod.Order.Base.Queries;
using Mod.Order.Base.Repositories;
using Mod.Order.Interfaces;
using Mod.Order.Models;


namespace Apps.EndpointDefinitions.OrderWebAPI;

public class OrderEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("api/orders", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllOrdersQuery()));
        app.MapPost("api/orders",
            ([FromServices] IMediator _mediator, [FromBody] OrderModel Order) =>
                _mediator.Send(new CreateOrderCommand(Order)));
        app.MapPost("api/orders/update-notification",
            ([FromServices] IMediator _mediator, [FromBody] OrderNotificationModel Order) =>
                _mediator.Send(new UpdateOrderNotificationCommand(Order)));
        app.MapPost("api/orders/update-payment",
            ([FromServices] IMediator _mediator, [FromBody] OrderPaymentInfoModel Order) =>
                _mediator.Send(new UpdateOrderPaymentInfoCommand(Order)));
    }

    public void DefineServices(IServiceCollection services)
    {
        
    }
}

