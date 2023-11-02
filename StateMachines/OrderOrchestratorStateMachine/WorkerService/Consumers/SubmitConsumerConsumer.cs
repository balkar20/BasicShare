namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class SubmitConsumerConsumer :
        IConsumer<SubmitConsumer>
    {
        public Task Consume(ConsumeContext<SubmitConsumer> context)
        {
            return Task.CompletedTask;
        }
    }
}