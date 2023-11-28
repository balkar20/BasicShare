namespace Company.StateMachines
{
    using Contracts;
    using MassTransit;

    public class OrderOrchestratorStateMachine :
        MassTransitStateMachine<OrderOrchestratorState> 
    {
        public OrderOrchestratorStateMachine()
        {
            InstanceState(x => x.CurrentState, Created);

            Event(() => OrderOrchestratorEvent, x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(OrderOrchestratorEvent)
                    .Then(context => context.Instance.Value = context.Data.Value)
                    .TransitionTo(Created)
            );

            SetCompletedWhenFinalized();
        }

        public State Created { get; private set; }

        public Event<OrderOrchestratorEvent> OrderOrchestratorEvent { get; private set; }
    }
}