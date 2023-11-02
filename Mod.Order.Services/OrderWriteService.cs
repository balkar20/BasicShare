using AutoMapper;
using Infrastructure.Interfaces;
using Mod.Order.EventData.Aggregates;
using Mod.Order.EventData.Events;
using Mod.Order.EventData.Events.Models;
using Mod.Order.Interfaces;
using Mod.Order.Models;

namespace Mod.Order.Services;

public class OrderWriteService: IOrderWriteService
{
    private readonly IAggregateRepository<OrderAggregate> _oerderAggregateRepository;
    protected readonly IMapper _mapper;
    

    public OrderWriteService(IMapper mapper, IAggregateRepository<OrderAggregate> oerderAggregateRepository)
    {
        _mapper = mapper;
        _oerderAggregateRepository = oerderAggregateRepository;
    }

    public async Task UpdateOrderNotification(OrderNotificationModel orderNotificationModel)
    {
        var notificationEventModel = _mapper.Map<OrderNotificationEventModel>(orderNotificationModel);
        var orderAggregate = await _oerderAggregateRepository.GetById(orderNotificationModel.OrderId);
        orderAggregate.UpdateNotification(notificationEventModel);
        await _oerderAggregateRepository.Save(orderAggregate, -1);
    }

    public async Task UpdateOrderPaymentInfo(OrderPaymentInfoModel orderNotificationModel)
    {
        var paymentInfoEventModel = _mapper.Map<OrderPaymentInfoEventModel>(orderNotificationModel);
        var orderAggregate = await _oerderAggregateRepository.GetById(orderNotificationModel.OrderId);
        orderAggregate.UpdatePaymentInfo(paymentInfoEventModel);
        await _oerderAggregateRepository.Save(orderAggregate, -1);
    }

    public async Task<OrderIdModel> CreateOrder(OrderModel order)
    {
        var creationData = _mapper.Map<OrderCreationDataModel>(order);
        var aggregate = new OrderAggregate(creationData);
        var model = new OrderIdModel
        {
            Version = await _oerderAggregateRepository.Save(aggregate, -1),
            OrderId = aggregate.Id
        };
        return model;
    }
}