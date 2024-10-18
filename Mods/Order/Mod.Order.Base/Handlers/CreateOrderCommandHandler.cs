using Core.Transfer;
using Infrastructure.Interfaces;
using MediatR;
using Mod.Order.Base.Commands;
using Mod.Order.Interfaces;
using Mod.Order.Models;

namespace Mod.Order.Base.Handlers;

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, ResponseResultWithData<OrderIdModel>>
{
    private IOrderWriteService _orderService;

    // public CreateOrderCommandHandler(IOrderRepository orderRepository, IRabbitMqProducer rabbitMqProducer)
    public CreateOrderCommandHandler(IOrderWriteService orderService)
    {
        // _orderRepository = orderRepository;
        _orderService = orderService;
    }

    public async Task<ResponseResultWithData<OrderIdModel>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var result = new ResponseResultWithData<OrderIdModel>
        {
            IsSuccess = false,
        };
        
        if (request.Order.Id == Guid.Empty)
        {
            request.Order.Id = Guid.NewGuid();
        }
        
        result.Data = await _orderService.CreateOrder(request.Order);
        result.IsSuccess = true;
        
        return result;
    }
}