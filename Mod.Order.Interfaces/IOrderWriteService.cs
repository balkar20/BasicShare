using Mod.Order.Models;

namespace Mod.Order.Interfaces;

public interface IOrderWriteService
{
        
    Task<OrderIdModel> CreateOrder(OrderModel order);
    
    Task UpdateOrderNotification(OrderNotificationModel orderNotificationModel);

    Task UpdateOrderPaymentInfo(OrderPaymentInfoModel orderNotificationModel);
}