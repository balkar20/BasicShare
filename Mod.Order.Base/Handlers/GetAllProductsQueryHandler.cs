using AutoMapper;
using Core.Base.DataBase.Entities;
using MediatR;
using Mod.Order.Base.Queries;
using Mod.Order.Interfaces;
using ModOrder.Models;

namespace Mod.Order.Base.Handlers;

public class GetAllOrdersQueryHandler: IRequestHandler<GetAllOrdersQuery, List<OrderModel>>
{
    private readonly IOrderRepository _OrderRepository;
    private readonly IOrderService _OrderService;

    public GetAllOrdersQueryHandler(IOrderRepository OrderRepository, IOrderService OrderService)
    {
        _OrderRepository = OrderRepository;
        _OrderService = OrderService;
    }
    
    public async Task<List<OrderModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _OrderService.GetAllOrders();
    }
}