using MediatR;
using Mod.Order.Models;

namespace Mod.Order.Base.Commands;

public record CreateOrderCommand(OrderModel Order) : IRequest<OrderModel>;