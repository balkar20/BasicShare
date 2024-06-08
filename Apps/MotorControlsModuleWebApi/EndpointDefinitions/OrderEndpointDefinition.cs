// using Infrastructure.Interfaces;
// using Infrastructure.Services;
// using MediatR;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.DependencyInjection;
// using Mod.Order.Base.Commands;
// using Mod.Order.Base.Queries;
// using Mod.Order.Base.Repositories;
// using Mod.Order.Interfaces;
// using Mod.Order.Models;
//
//
// namespace Apps.EndpointDefinitions.MotorControlsModuleWebAPI;
//
// public class OrderEndpointDefinition : IEndpointDefinition
// {
//     public void DefineEndpoints(WebApplication app)
//     {
//         app.MapGet("api/orders", ([FromServices] IMediator _mediator) => _mediator.Send(new GetAllOrdersQuery()));
//         app.MapPost("api/orders",
//             ([FromServices] IMediator _mediator, [FromBody] OrderModel Order) =>
//                 _mediator.Send(new CreateOrderCommand(Order)));
//         app.MapPut("api/orders",
//             ([FromServices] IMediator _mediator, [FromBody] OrderModel Order) =>
//                 _mediator.Send(new UpdateOrderCommand(Order)));
//     }
//
//     public void DefineServices(IServiceCollection services)
//     {
//         services.AddScoped<IOrderRepository, OrderRepository>();
//         services.AddScoped<IOrderService, OrderService>();
//         services.AddScoped<IRabitMQProducer, RabitMQProducer>();
//     }
// }