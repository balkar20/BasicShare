namespace Company.StateMachines
{
    using Contracts;
    using MassTransit;

    public class OrderProcessingStateMachine :
        MassTransitStateMachine<OrderProcessingState> 
    {
        public OrderProcessingStateMachine()
        {
            InstanceState(x => x.CurrentState, Created);

            Event(() => OrderProcessingEvent, x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(OrderProcessingEvent)
                    .Then(context => context.Instance.Value = context.Data.Value)
                    .TransitionTo(Created)
            );

            SetCompletedWhenFinalized();
        }

        public State Created { get; private set; }

        public Event<OrderProcessingEvent> OrderProcessingEvent { get; private set; }
    }
}