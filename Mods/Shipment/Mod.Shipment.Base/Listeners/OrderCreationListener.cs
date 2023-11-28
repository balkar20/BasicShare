using Core.Transfer.Mods.Order;
using Infrastructure.Interfaces;
using Mod.Shipment.Base.Listeners.Interfaces;
using Mod.Shipment.Interfaces;
using Mod.Shipment.Models;

namespace Mod.Shipment.Base.Listeners;

public class OrderCreationListener: IOrderCreationListener
{
    private readonly IMessageBusReader _messageBusReader;
    private readonly IShipmentRepository _productRepository;

    public OrderCreationListener(IMessageBusReader messageBusReader, IShipmentRepository productRepository)
    {
        _messageBusReader = messageBusReader;
        _productRepository = productRepository;
    }

    public void Handle(OrderModel orderModel)
    {
        SaveShipmentFromOrder(orderModel);
    }

    public void RegisterHandler()
    {
        _messageBusReader.ListenEventsFromQue<OrderModel>(Handle);
    }

    private async Task SaveShipmentFromOrder(OrderModel orderModel)
    {
        await _productRepository.AddAsync(new ShipmentModel()
        {
            Name = orderModel.Description,
            Description = orderModel.Description
        });
    }
}