namespace Company.Consumers
{
    using MassTransit;

    public class SubmitConsumerConsumerDefinition :
        ConsumerDefinition<SubmitConsumerConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<SubmitConsumerConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}