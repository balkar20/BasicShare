using System;
using EventBus.Constants;
using EventBus.Events;
using EventBus.Events.Interfaces;
using EventBus.Messages;
using EventBus.Messages.Interfaces;
using MassTransit;
using OrderOrchestratorStateMachine.DbContext;
using SagaOrchestrationStateMachine.StateInstances;
using Serilog;

namespace SagaOrchestrationStateMachine.StateMachines;

public class OrderStateMachine : MassTransitStateMachine<OrderStateInstance>
{
    private readonly Serilog.ILogger _logger;

    // Commands
    public Event<ICreateOrderMessage> CreateOrderMessage { get; private set; }

    // Events
    public Event<IStockReservedEvent> StockReservedEvent { get; private set; }
    public Event<IStockReservationFailedEvent> StockReservationFailedEvent { get; private set; }
    public Event<IPaymentCompletedEvent> PaymentCompletedEvent { get; private set; }
    public Event<IPaymentFailedEvent> PaymentFailedEvent { get; private set; }

    // States
    public State OrderCreated { get; private set; }
    public State StockReserved { get; private set; }
    public State StockReservationFailed { get; private set; }
    public State PaymentCompleted { get; private set; }
    public State PaymentFailed { get; private set; }

    public OrderStateMachine() //ILogger<OrderStateMachine> logger)
    {
        _logger = Serilog.Log.Logger;
        InstanceState(x => x.CurrentState);
        // Event Correlation
        Event(() => CreateOrderMessage, x =>
            x.CorrelateById(m => m.Message.OrderId)
                .SelectId(m => m.Message.OrderId));
        Event(() => StockReservedEvent, x => x.CorrelateById(y => y.Message.CorrelationId));
        Event(() => StockReservationFailedEvent, x => x.CorrelateById(y => y.Message.CorrelationId));
        Event(() => PaymentCompletedEvent, x => x.CorrelateById(y => y.Message.CorrelationId));

        Initially(
            When(CreateOrderMessage)
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId).Information(
                        "CreateOrderMessage received in OrderStateMachine: {ContextSaga} ", context.Saga);
                })
                .Then(context =>
                {
                    context.Saga.CustomerId = context.Message.CustomerId;
                    context.Saga.OrderId = context.Message.OrderId;
                    context.Saga.PaymentAccountId = context.Message.PaymentAccountId;
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId).Information(
                        "CreateOrderMessage received in OrderStateMachine: {ContextSaga} ", context.Saga);
                })
                .Publish(
                    context => new OrderCreatedEvent
                    {
                        CorrelationId = context.Saga.CorrelationId,
                        OrderItemList = context.Message.OrderItemList
                    })
                .TransitionTo(OrderCreated)
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId).Information(
                        "OrderCreatedEvent published in OrderStateMachine: {ContextSaga} ", context.Saga);
                }));

        During(OrderCreated,
            When(StockReservedEvent)
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId).Information(
                        "StockReservedEvent received in OrderStateMachine: {ContextSaga} ", context.Saga);
                })
                .TransitionTo(StockReserved)
                .Send(new Uri($"queue:{QueuesConsts.CompletePaymentMessageQueueName}"),
                    context => new CompletePaymentMessage
                    {
                        CorrelationId = context.Saga.CorrelationId,
                        TotalPrice = context.Saga.TotalPrice,
                        CustomerId = context.Saga.CustomerId,
                        OrderItemList = context.Message.OrderItemList
                    })
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId).Information(
                        "CompletePaymentMessage sent in OrderStateMachine: {ContextSaga} ", context.Saga);
                }),
            When(StockReservationFailedEvent)
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId).Information(
                        "StockReservationFailedEvent received in OrderStateMachine: {ContextSaga} ", context.Saga);
                })
                .TransitionTo(StockReservationFailed)
                .Publish(
                    context => new OrderFailedEvent
                    {
                        OrderId = context.Saga.OrderId,
                        CustomerId = context.Saga.CustomerId,
                        ErrorMessage = context.Message.ErrorMessage
                    })
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId)
                        .Information("OrderFailedEvent published in OrderStateMachine: {ContextSaga} ",
                            context.Saga);
                })
        );
        
        During(StockReserved,
            When(PaymentCompletedEvent)
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId).Information(
                        "PaymentCompletedEvent received in OrderStateMachine: {ContextSaga} ", context.Saga);
                })
                .TransitionTo(PaymentCompleted)
                .Publish(
                    context => new OrderCompletedEvent
                    {
                        OrderId = context.Saga.OrderId,
                        CustomerId = context.Saga.CustomerId
                    })
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId).Information(
                        "OrderCompletedEvent published in OrderStateMachine: {ContextSaga} ", context.Saga);
                })
                .Finalize(),
            When(PaymentFailedEvent)
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId).Information(
                        "PaymentFailedEvent received in OrderStateMachine: {ContextSaga} ", context.Saga);
                })
                .Publish(context => new OrderFailedEvent
                {
                    OrderId = context.Saga.OrderId,
                    CustomerId = context.Saga.CustomerId,
                    ErrorMessage = context.Message.ErrorMessage
                })
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId)
                        .Information("OrderFailedEvent published in OrderStateMachine: {ContextSaga} ",
                            context.Saga);
                })
                .Send(new Uri($"queue:{QueuesConsts.StockRollBackMessageQueueName}"),
                    context => new StockRollbackMessage
                    {
                        OrderItemList = context.Message.OrderItemList
                    })
                .Then(context =>
                {
                    _logger.ForContext("CorrelationId", context.Saga.CorrelationId)
                        .Information("StockRollbackMessage sent in OrderStateMachine: {ContextSaga} ",
                            context.Saga);
                })
                .TransitionTo(PaymentFailed)
        );
    }
}