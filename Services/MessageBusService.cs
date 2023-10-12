using System.Text;
using AutoMapper;
using Core.Base.ConfigurationInterfaces;
using Infrastructure.Interfaces;
using MassTransit;
using MassTransitBase.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Serilog;

namespace Infrastructure.Services;

public class MessageBusService : IMessageBusService
{
    private readonly IMessageBrokerConfiguration _configuration;
    private readonly ILogger _logger;
    private readonly IBus _bus;
    private readonly IMapper _mapper;
    
    public MessageBusService(IMessageBrokerConfiguration configuration, ILogger logger, IBus bus)
    {
        _configuration = configuration;
        _logger = logger;
        _bus = bus;
    }
    
    public async Task PublishMessage<T>(T message)
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
            // var uri = new Uri("rabbitmq://localhost:15672/product-service");
            // var endpoint = _bus.GetSendEndpoint(uri);
            var maaped = _mapper.Map<IBaseMessage>(message);
            var t = _bus.Publish(maaped);
            
            // var res = endpoint.Result;
        }
        
        // var body = Encoding.UTF8.GetBytes(json);
        // //put the data on to the product queue
        // channel.BasicPublish(exchange: _configuration.ExchangeName, routingKey: _configuration.QueName, body: body);
    }
}