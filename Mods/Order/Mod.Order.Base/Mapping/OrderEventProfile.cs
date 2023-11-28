using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.Order.EventData.Events.Models;
using Mod.Order.Models;
using EventsOrderStatus = Mod.Order.EventData.Enums.OrderStatus;
using EventsOrderNotificationType = Mod.Order.EventData.Enums.NotificationType;
using EventsOrderType = Mod.Order.EventData.Enums.OrderType;
using OrderModelCustomerInfo = Mod.Order.Models.CustomerInfo;
using OrderModelOrderStatus = Mod.Order.Models.Enums.OrderStatus;
using OrderModelNotificationType = Mod.Order.Models.Enums.NotificationType;
using OrderModelOrderType = Mod.Order.Models.Enums.OrderType;

namespace Mod.Order.Base.Mapping;

public class OrderEventProfile: Profile
{
    public OrderEventProfile()
    {
        CreateMap<OrderModel, OrderEntity>().ReverseMap();
        
        CreateMap<OrderModel, OrderCreationDataModel>()
            .ForMember(o => o.Description, 
                m => 
                    m.MapFrom(k => k.Description))
            .ForMember(o => o.OrderType, 
                m => 
                    m.MapFrom(k => k.OrderType))
            .ForMember(o => o.OrderPayloadId, 
                m => 
                    m.MapFrom(k => k.OrderPayloadId))
            .ForMember(o => o.OrderPaymentInfoEventModel, 
                m => 
                    m.MapFrom(k => k.OrderPaymentInfoModel))
            .ForMember(o => o.NotificationEventModel, 
                m => 
                    m.MapFrom(k => k.NotificationModel))
            .ForMember(o => o.CustomerId, 
                m => 
                    m.MapFrom(k => k.CustomerId))
            .ReverseMap();
        
        // CreateMap<OrderModel, OrderCreationDataModel>()
        //     .ForCtorParam(ctorParamName: "Description", 
        //         m => 
        //             m.MapFrom(k => k.Description))
        //     .ForCtorParam(ctorParamName: "OrderType", 
        //         m => 
        //             m.MapFrom(k => k.OrderType))
        //     .ForCtorParam(ctorParamName: "OrderPayloadId", 
        //         m => 
        //             m.MapFrom(k => k.OrderPayloadId))
        //     .ForCtorParam(ctorParamName: "PaymentInfo", 
        //         m => 
        //             m.MapFrom(k => k.OrderPaymentInfoModel))
        //     .ForCtorParam(ctorParamName: "Notification", 
        //         m => 
        //             m.MapFrom(k => k.NotificationModel))
        //     .ForCtorParam(ctorParamName: "CustomerId", 
        //         m => 
        //             m.MapFrom(k => k.CustomerId))
        //     .ReverseMap();
        
        CreateMap<OrderPaymentInfoEventModel, OrderPaymentInfoModel>().ReverseMap();
        CreateMap<CustomerInfoEventModel, OrderModelCustomerInfo>().ReverseMap();
        CreateMap<OrderNotificationEventModel, OrderNotificationModel>().ReverseMap();
        CreateMap<EventsOrderStatus, OrderModelOrderStatus>().ReverseMap();
        CreateMap<EventsOrderType, OrderModelOrderType>().ReverseMap();
        CreateMap<EventsOrderNotificationType, OrderModelNotificationType>().ReverseMap();
    }
}