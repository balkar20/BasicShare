using MediatR;
using Mod.Order.Models;

namespace Mod.Order.Base.Queries;

public record GetAllOrdersQuery : IRequest<List<OrderModel>>;