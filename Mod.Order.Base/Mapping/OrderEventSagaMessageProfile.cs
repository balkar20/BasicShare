using AutoMapper;
using Data.Base.Objects;
using EventBus.Messages;
using MassTransitBase;
using Mod.Order.EventData.Events;
using MongoObjects.Order;

namespace Mod.Order.Base.Mapping;

public class OrderEventSagaMessageProfile: Profile
{
    public OrderEventSagaMessageProfile()
    {
        CreateMap<EventObject, IBaseSagaMessage>()
            .Include<OrderCreatedEvent, CreateOrderMessage>().ReverseMap();
        // CreateMap<CreateOrderMessage, OrderCreatedEvent>();
    }
}