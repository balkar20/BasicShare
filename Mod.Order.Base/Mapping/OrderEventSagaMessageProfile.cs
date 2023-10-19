using AutoMapper;
using Data.Base.Objects;
using EventBus.Messages;
using EventBus.Messages.Interfaces;
using MassTransitBase;
using Mod.Order.EventData.Events;
using MongoObjects.Order;

namespace Mod.Order.Base.Mapping;

public class OrderEventSagaMessageProfile: Profile
{
    public OrderEventSagaMessageProfile()
    {
        CreateMap<CreateOrderMessage, OrderCreatedEvent>()
            .ForMember(x=> x.Id, 
                opt => 
                    opt.MapFrom(src => src.OrderId))
            .ForMember(x=> x.CustomerId, 
                opt => 
                    opt.MapFrom(src => src.CustomerId))
            .ReverseMap();
        CreateMap<EventObject, IBaseSagaMessage>()
            .Include<OrderCreatedEvent, CreateOrderMessage>().ReverseMap();
        CreateMap<EventObject, ICreateOrderMessage>()
            .Include<OrderCreatedEvent, CreateOrderMessage>().ReverseMap();
    }
}