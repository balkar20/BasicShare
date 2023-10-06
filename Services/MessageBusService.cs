using System.Text;
using Core.Base.ConfigurationInterfaces;
using Infrastructure.Interfaces;
using MassTransit;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Serilog;

namespace Infrastructure.Services;

public class MessageBusService : IMessageBusService
{
    private readonly IMessageBrokerConfiguration _configuration;
    private readonly ILogger _logger;
    private readonly IBus _bus;
    

    public MessageBusService(IMessageBrokerConfiguration configuration, ILogger logger, IBus bus)
    {
        _configuration = configuration;
        _logger = logger;
        _bus = bus;
    }
    
    public void PublishMessage<T>(T message)
    {
        //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
        // var factory = new ConnectionFactory
        // {
        //     HostName = _configuration.HostName
        // };
        //
        // //Create the RabbitMQ connection using connection factory details as i mentioned above
        // var connection = factory.CreateConnection();
        // //Here we create channel with session and model
        // using var channel = connection.CreateModel();
        //
        // //declare the queue after mentioning name and a few property related to that
        // channel.QueueDeclare(_configuration.QueName, exclusive: false);
        //Serialize the message
        // var json = JsonConvert.SerializeObject(message);

        if (message != null)
        {
            _bus.Publish(message);
        }
        
        // var body = Encoding.UTF8.GetBytes(json);
        // //put the data on to the product queue
        // channel.BasicPublish(exchange: _configuration.ExchangeName, routingKey: _configuration.QueName, body: body);
    }
}