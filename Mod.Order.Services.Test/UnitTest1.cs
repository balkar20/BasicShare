using AutoMapper;
using Data.Base.Objects;
using EventBus.Messages;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using MassTransitBase;
using Mod.Order.EventData.Aggregates;
using Mod.Order.EventData.Events;
using Mod.Order.EventData.Events.Models;
using Mod.Order.Models;
using Mod.Order.Models.Enums;
using MongoDataServices;
using MongoObjects;
using Moq;
using CustomerInfo = Mod.Order.EventData.Events.Models.CustomerInfo;
using OrderNotification = Mod.Order.Models.OrderNotification;
using OrderType = Mod.Order.EventData.Enums.OrderType;
using PaymentInfo = Mod.Order.EventData.Events.Models.PaymentInfo;

namespace Mod.Order.Services.Test;

public class UnitTest1
{
    private Mock<IMessageBusService> _publisherMock;
    private Mock<IDataCollectionService<EventDocument>> _eventStorageMock;
    private AggregateStorage _aggregateStorage;
    
    //
    // [Theory]
    //

    public class Order
    {
        public int Id { get; set; }
    }

    public class OnlineOrder : Order
    {
        public int  Ho { get; set; }
    }

    public class MailOrder : Order
    {
        public string  Mail { get; set; }
    }

    public class OrderDto
    {
        public int Id { get; set; }
    }

    public class OnlineOrderDto : OrderDto
    {
        public int  Ho { get; set; }
    }

    public class MailOrderDto : OrderDto
    {
        public string  Mail { get; set; }
    }

    [Fact]
    public async Task TestMapperEvents()
    {
        var configuration = new MapperConfiguration(cfg => {
            cfg.CreateMap<Order, OrderDto>()
                .Include<OnlineOrder, OnlineOrderDto>()
                .Include<MailOrder, MailOrderDto>();
            cfg.CreateMap<OnlineOrder, OnlineOrderDto>();
            cfg.CreateMap<MailOrder, MailOrderDto>();
            
            
            cfg.CreateMap<CreateOrderMessage, OrderCreatedEvent>()
                .ForMember(x=> x.OrderProductId, 
                    opt => 
                        opt.MapFrom(src => src.OrderId))
                .ForMember(x=> x.Description, 
                    opt => 
                        opt.MapFrom(src => src.CustomerId))
                .ReverseMap();
            cfg.CreateMap<EventObject, IBaseSagaMessage>()
                .Include<OrderCreatedEvent, CreateOrderMessage>()
                .ReverseMap();
        });
        var mapper = configuration.CreateMapper();
        // var orderCreatedEvent = 
        
        OrderCreatedEvent evt = new OrderCreatedEvent(
            Description: "Default description",
            OrderType: OrderType.Product,
            OrderProductId: 123,
            PaymentInfo: new PaymentInfo(),
            Notification: new EventData.Events.Models.OrderNotification(),
            customerId: "hj"
        );

        IBaseSagaMessage msg = mapper.Map<IBaseSagaMessage>(evt);

        CreateOrderMessage cmg = msg as CreateOrderMessage;
        
        Assert.Equal(cmg.OrderId, evt.OrderProductId);
        Assert.Equal(cmg.CustomerId, evt.Description);
    }
    
    [Fact]
    public async Task TestMapper()
    {
        var configuration = new MapperConfiguration(cfg => {
            cfg.CreateMap<Order, OrderDto>()
                .Include<OnlineOrder, OnlineOrderDto>()
                .Include<MailOrder, MailOrderDto>();
            cfg.CreateMap<OnlineOrder, OnlineOrderDto>();
            cfg.CreateMap<MailOrder, MailOrderDto>();
            
            
            // cfg.CreateMap<CreateOrderMessage, OrderCreatedEvent>();
            cfg.CreateMap<EventObject, IBaseSagaMessage>()
                .Include<OrderCreatedEvent, CreateOrderMessage>().ReverseMap();
        });

        var mapper = configuration.CreateMapper();
        // Perform Mapping
        var order = new OnlineOrder()
        {
            Id = 1,
            Ho = 2
        };
        
        Order orderDerr = order;
        
        
        var mapped = mapper.Map<OrderDto>(orderDerr);
        var mapped2 = mapper.Map<OnlineOrderDto>(orderDerr);
        var mapped3 = mapper.Map(orderDerr, typeof(OnlineOrder), typeof(OrderDto));
        
        var type = mapped.GetType();
        var type3 = mapped3.GetType();
        OnlineOrderDto? odto = mapped as OnlineOrderDto;
        OnlineOrderDto? odto3 = mapped3 as OnlineOrderDto;
        Assert.IsType<OnlineOrderDto>(mapped);
        Assert.IsType<OnlineOrderDto>(mapped3);
        Assert.Equal(mapped2.Ho, order.Ho);
        Assert.Equal(odto.Ho, order.Ho);
        Assert.Equal(odto3.Ho, odto3.Ho);
    }
    
    // [Fact]
    // public async Task SaveEvents_WithValidData_ShouldSaveEventsAndPublishMeges()
    // {
    //     
    //     OrderModel order = new OrderModel
    //     {
    //         Id = 0,
    //         Description = "null",
    //         OrderType = OrderType.Product,
    //         OrderStatus = OrderStatus.Created,
    //         OrderPayloadId = 0,
    //         PaymentInfo = new PaymentInfo(),
    //         Notification = new OrderNotification(),
    //         CustomerInfo = new CustomerInfo()
    //     };
    //     // Arrange
    //     var oag = new OrderAggregate(Guid.NewGuid(), order);
    //     
    //     
    //     Assert.Equal("null", oag.Description);
    //     
    // }
    //
    // [Fact]
    // public async Task SaveEvents_WithValidData_ShouldSaveEvtsAndPublishMeges()
    // {
    //     
    //     
    //     OrderModel order = new OrderModel
    //     {
    //         Id = 0,
    //         Description = "null",
    //         OrderType = OrderType.Product,
    //         OrderStatus = OrderStatus.Created,
    //         OrderPayloadId = 0,
    //         PaymentInfo = new PaymentInfo(),
    //         Notification = new OrderNotification(),
    //         CustomerInfo = new CustomerInfo()
    //     };
    //     // Arrange
    //     var oag = new OrderAggregate(Guid.NewGuid(), order);
    //     
    //     
    //     Assert.Equal("null", oag.Description);
    //     
    // }
}