using Core.Transfer.Mods.Order;
using Infrastructure.Interfaces;
using Mod.MotorControlsModule.Base.Listeners.Interfaces;
using Mod.MotorControlsModule.Interfaces;
using Mod.MotorControlsModule.Models;

namespace Mod.MotorControlsModule.Base.Listeners;

public class OrderCreationListener: IOrderCreationListener
{
    private readonly IMessageBusReader _messageBusReader;
    private readonly IMotorControlsModuleRepository _productRepository;

    public OrderCreationListener(IMessageBusReader messageBusReader, IMotorControlsModuleRepository productRepository)
    {
        _messageBusReader = messageBusReader;
        _productRepository = productRepository;
    }

    public void Handle(OrderModel orderModel)
    {
        SaveMotorControlsModuleFromOrder(orderModel);
    }

    public void RegisterHandler()
    {
        _messageBusReader.ListenEventsFromQue<OrderModel>(Handle);
    }

    private async Task SaveMotorControlsModuleFromOrder(OrderModel orderModel)
    {
        await _productRepository.AddAsync(new MotorControlsModuleModel()
        {
            Name = orderModel.Description,
            Description = orderModel.Description
        });
    }
}