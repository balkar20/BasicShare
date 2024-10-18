using Core.Transfer.Mods.Order;
using Infrastructure.Interfaces;
using MassTransit;
using Mod.Order.EventData.Events;
using Mod.Product.Base.Listeners.Interfaces;
using Mod.Product.Interfaces;
using Mod.Product.Models;

namespace Mod.Product.Base.Listeners;

public class OrderCreationListener: IConsumer<OrderCreatedEvent>
{
    private readonly IMessageBusReader _messageBusReader;
    private readonly IProductRepository _productRepository;

    public OrderCreationListener(IMessageBusReader messageBusReader, IProductRepository productRepository)
    {
        _messageBusReader = messageBusReader;
        _productRepository = productRepository;
    }

    public void Handle(OrderModel orderModel)
    {
        SaveProductFromOrder(orderModel);
    }

    public void RegisterHandler()
    {
        _messageBusReader.ListenEventsFromQue<OrderModel>(Handle);
    }

    private async Task SaveProductFromOrder(OrderModel orderModel)
    {
        await _productRepository.AddAsync(new ProductModel()
        {
            Name = orderModel.Description,
            Description = orderModel.Description
        });
    }

    public Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        throw new NotImplementedException();
    }
}