using Core.Transfer.Mods.Order;
using Infrastructure.Interfaces;
using Mod.PowerSupply.Base.Listeners.Interfaces;
using Mod.PowerSupply.Interfaces;
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Base.Listeners;

public class OrderCreationListener: IOrderCreationListener
{
    private readonly IMessageBusReader _messageBusReader;
    private readonly IPowerSupplyRepository _productRepository;

    public OrderCreationListener(IMessageBusReader messageBusReader, IPowerSupplyRepository productRepository)
    {
        _messageBusReader = messageBusReader;
        _productRepository = productRepository;
    }

    public void Handle(OrderModel orderModel)
    {
        SavePowerSupplyFromOrder(orderModel);
    }

    public void RegisterHandler()
    {
        _messageBusReader.ListenEventsFromQue<OrderModel>(Handle);
    }

    private async Task SavePowerSupplyFromOrder(OrderModel orderModel)
    {
        await _productRepository.AddAsync(new PowerSupplyModel()
        {
            Name = orderModel.Description,
            Description = orderModel.Description
        });
    }
}