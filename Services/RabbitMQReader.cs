using System.Text;
using Core.Base.Configuration;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;

namespace Infrastructure.Services;

public class RabbitMQReader: IRabbitMQReader
{
    private readonly MessageBrokerConfiguration _configuration;
    private readonly ILogger _logger;

    public RabbitMQReader(IOptions<MessageBrokerConfiguration> configuration)
    {
        _configuration = configuration.Value;
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
                _logger.Debug($"Message from Que essage received: {message}");
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