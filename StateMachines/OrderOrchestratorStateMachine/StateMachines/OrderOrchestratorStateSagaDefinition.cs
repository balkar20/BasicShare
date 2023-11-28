namespace Company.StateMachines
{
    using MassTransit;

    public class OrderOrchestratorStateSagaDefinition :
        SagaDefinition<OrderOrchestratorState>
    {
        protected override void ConfigureSaga(IReceiveEndpointConfigurator endpointConfigurator, ISagaConfigurator<OrderOrchestratorState> sagaConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}