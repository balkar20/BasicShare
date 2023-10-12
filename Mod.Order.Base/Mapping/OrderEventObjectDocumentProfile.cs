using AutoMapper;
using Data.Base.Objects;
using Mod.Order.EventData.Events;
using MongoObjects;
using MongoObjects.Order;

using ObjectOrderNotification = MongoObjects.Order.OrderNotification;
using ObjectOrderPaymentInfo = MongoObjects.Order.PaymentInfo;
using ObjectOrderCustomerInfo = MongoObjects.Order.CustomerInfo;
using ObjectOrderType = MongoObjects.Order.Enums.OrderType;
using ObjectOrderStatus = MongoObjects.Order.Enums.OrderStatus;
using ObjectOrderNotificationType = MongoObjects.Order.Enums.NotificationType;

using DocumentOrderNotification = Mod.Order.EventData.Events.Models.OrderNotification;
using DocumentOrderPaymentInfo = Mod.Order.EventData.Events.Models.PaymentInfo;
using DocumentOrderCustomerInfo = Mod.Order.EventData.Events.Models.CustomerInfo;
using DocumentOrderType = Mod.Order.EventData.Enums.OrderType;
using DocumentOrderStatus = Mod.Order.EventData.Enums.OrderStatus;
using DocumentOrderNotificationType = Mod.Order.EventData.Enums.NotificationType;

namespace Mod.Order.Base.Mapping;

public class OrderEventObjectDocumentProfile : Profile
{
    public OrderEventObjectDocumentProfile()
    {
        CreateMap<EventObject, EventDocument>()
            .Include<OrderCreatedEvent, OrderCreatedDocument>();
        CreateMap<OrderCreatedEvent, OrderCreatedDocument>().ReverseMap();
        
        CreateMap<ObjectOrderNotification, DocumentOrderNotification>().ReverseMap();
        CreateMap<ObjectOrderPaymentInfo, DocumentOrderPaymentInfo>().ReverseMap();
        CreateMap<ObjectOrderCustomerInfo, DocumentOrderCustomerInfo>().ReverseMap();
        CreateMap<ObjectOrderType, DocumentOrderType>().ReverseMap();
        CreateMap<ObjectOrderStatus, DocumentOrderStatus>().ReverseMap();
        CreateMap<ObjectOrderNotificationType, DocumentOrderNotificationType>().ReverseMap();
    }
}