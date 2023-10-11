using AutoMapper;
using Core.Base.DataBase.Entities;
using Data.Ordering.Objects;
using Mod.Order.EventData.Events;
using Mod.Order.EventData.Events.Models;
using Mod.Order.Models;
using MongoObjects;
using MongoObjects.Order;
using EventsPaymentInfo = Mod.Order.EventData.Events.Models.PaymentInfo;
using EventsCustomerInfo = Mod.Order.EventData.Events.Models.CustomerInfo;
using EventsOrderNotification = Mod.Order.EventData.Events.Models.OrderNotification;
using EventsOrderStatus = Mod.Order.EventData.Enums.OrderStatus;
using EventsOrderNotificationType = Mod.Order.EventData.Enums.NotificationType;
using EventsOrderType = Mod.Order.EventData.Enums.OrderType;

using OrderModelPaymentInfo = Mod.Order.Models.PaymentInfo;
using OrderModelCustomerInfo = Mod.Order.Models.CustomerInfo;
using OrderModelOrderNotification = Mod.Order.Models.OrderNotification;
using OrderModelOrderStatus = Mod.Order.Models.Enums.OrderStatus;
using OrderModelNotificationType = Mod.Order.Models.Enums.NotificationType;
using OrderModelOrderType = Mod.Order.Models.Enums.OrderType;

namespace Mod.Order.Base.Mapping;

public class OrderEventProfile: Profile
{
    public OrderEventProfile()
    {
        CreateMap<OrderModel, OrderEntity>().ReverseMap();
        
        CreateMap<OrderModel, OrderCreationData>().ReverseMap();
        
        CreateMap<EventsPaymentInfo, OrderModelPaymentInfo>().ReverseMap();
        CreateMap<EventsCustomerInfo, OrderModelCustomerInfo>().ReverseMap();
        CreateMap<EventsOrderNotification, OrderModelOrderNotification>().ReverseMap();
        CreateMap<EventsOrderStatus, OrderModelOrderStatus>().ReverseMap();
        CreateMap<EventsOrderType, OrderModelOrderType>().ReverseMap();
        CreateMap<EventsOrderNotificationType, OrderModelNotificationType>().ReverseMap();
    }
}