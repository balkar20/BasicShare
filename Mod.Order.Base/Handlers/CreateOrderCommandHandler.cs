using Core.Transfer;
using Infrastructure.Interfaces;
using MediatR;
using Mod.Order.Base.Commands;

namespace Mod.Order.Base.Handlers;

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, BaseResponseResult>
{
    // private readonly IOrderRepository _orderRepository;
    private readonly IRabbitMqProducer _rabbitMqProducer;

    // public CreateOrderCommandHandler(IOrderRepository orderRepository, IRabbitMqProducer rabbitMqProducer)
    public CreateOrderCommandHandler(IRabbitMqProducer rabbitMqProducer)
    {
        // _orderRepository = orderRepository;
        _rabbitMqProducer = rabbitMqProducer;
    }

    public async Task<BaseResponseResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var result = new BaseResponseResult()
        {
            IsSuccess = false
        };
        try
        {
            // var createdOrder = await _orderRepository.AddAsync(request.Order);
            // _rabbitMqProducer.SendMessage(createdOrder);
            _rabbitMqProducer.SendMessage(request.Order);
            result.IsSuccess = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return result;
    }
}