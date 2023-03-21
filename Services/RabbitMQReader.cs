using System.Text;
using Core.Base.ConfigurationInterfaces;
using Infrastructure.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;

namespace Infrastructure.Services;

public class RabbitMQReader: IRabbitMQReader
{
    private readonly IMessageBrokerConfiguration _configuration;
    private readonly ILogger _logger;

    public RabbitMQReader(IMessageBrokerConfiguration configuration, ILogger logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public void ListenEventsFromQue<TModel>(Action<TModel> handler)
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration.HostName
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();
            channel.QueueDeclare(_configuration.QueName, exclusive: false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var resultModel = JsonConvert.DeserializeObject<TModel>(message);

                handler(resultModel);
                _logger.Debug($"Message from Que message received: {message}");
            };
        
            channel.BasicConsume(queue: _configuration.QueName, autoAck: true, consumer: consumer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
}