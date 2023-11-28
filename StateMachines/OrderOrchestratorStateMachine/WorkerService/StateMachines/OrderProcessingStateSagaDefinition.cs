namespace Company.StateMachines
{
    using MassTransit;

    public class OrderProcessingStateSagaDefinition :
        SagaDefinition<OrderProcessingState>
    {
        protected override void ConfigureSaga(IReceiveEndpointConfigurator endpointConfigurator, ISagaConfigurator<OrderProcessingState> sagaConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}