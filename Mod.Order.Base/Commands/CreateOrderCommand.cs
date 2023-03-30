using MediatR;
using Mod.Order.Models;
using Core.Transfer;

namespace Mod.Order.Base.Commands;

public record CreateOrderCommand(OrderModel Order) : IRequest<BaseResponseResult>;