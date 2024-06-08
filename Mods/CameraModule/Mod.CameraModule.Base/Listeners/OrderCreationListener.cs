using Core.Transfer.Mods.Order;
using Infrastructure.Interfaces;
using Mod.CameraModule.Base.Listeners.Interfaces;
using Mod.CameraModule.Interfaces;
using Mod.CameraModule.Models;

namespace Mod.CameraModule.Base.Listeners;

public class OrderCreationListener: IOrderCreationListener
{
    private readonly IMessageBusReader _messageBusReader;
    private readonly ICameraModuleRepository _productRepository;

    public OrderCreationListener(IMessageBusReader messageBusReader, ICameraModuleRepository productRepository)
    {
        _messageBusReader = messageBusReader;
        _productRepository = productRepository;
    }

    public void Handle(OrderModel orderModel)
    {
        SaveCameraModuleFromOrder(orderModel);
    }

    public void RegisterHandler()
    {
        _messageBusReader.ListenEventsFromQue<OrderModel>(Handle);
    }

    private async Task SaveCameraModuleFromOrder(OrderModel orderModel)
    {
        await _productRepository.AddAsync(new CameraModuleModel()
        {
            Name = orderModel.Description,
            Description = orderModel.Description
        });
    }
}