using MediatR;
using Mod.Order.Models;

namespace Mod.Order.Base.Commands;

public record UpdateOrderCommand(OrderModel Order) : IRequest<OrderModel>;