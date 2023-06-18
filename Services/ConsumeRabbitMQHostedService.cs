using System.Text;
using Core.Base.ConfigurationInterfaces;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;

namespace Infrastructure.Services;

public class ConsumeRabbitMQHostedService<TDataModel>: BackgroundService  
{  
    protected readonly ILogger _logger;  
    private IConnection _connection;  
    private IModel _channel;  
    private readonly IMessageBrokerConfiguration _configuration;
    protected Action<TDataModel> handler;
  
    public ConsumeRabbitMQHostedService(ILogger logger, IMessageBrokerConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;

        InitRabbitMQ();
    }  
  
    private void InitRabbitMQ()  
    {  
        var factory = new ConnectionFactory { HostName = _configuration.HostName, Port = _configuration.Port, UserName = _configuration.UserName, Password = _configuration.Password};  
  
        // create connection  
        _connection = factory.CreateConnection();  
  
        // create channel  
        var connection = factory.CreateConnection();

        _channel = connection.CreateModel();
        _channel.QueueDeclare(_configuration.QueName, exclusive: false);

        // _channel.ExchangeDeclare(_configuration.ExchangeName, ExchangeType.Topic);  
        // _channel.QueueDeclare(_configuration.QueName, false, false, false, null);  
        // _channel.QueueBind(_configuration.QueName, _configuration.ExchangeName, _configuration.QueName, null);  
        // _channel.BasicQos(0, 1, false);  
  
        _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;  
    }  
  
    protected override Task ExecuteAsync(CancellationToken stoppingToken)  
    {  
        stoppingToken.ThrowIfCancellationRequested();  
  
        var consumer = new EventingBasicConsumer(_channel);  
        consumer.Received += (ch, ea) =>  
        {  
            // received message  
            var content = Encoding.UTF8.GetString(ea.Body.Span);;  
  
            // handle the received message  
            HandleMessage(content);  
            _channel.BasicAck(ea.DeliveryTag, false);  
        };  
  
        consumer.Shutdown += OnConsumerShutdown;  
        consumer.Registered += OnConsumerRegistered;  
        consumer.Unregistered += OnConsumerUnregistered;  
        consumer.ConsumerCancelled += OnConsumerConsumerCancelled;  
  
        _channel.BasicConsume(_configuration.QueName, false, consumer);  
        return Task.CompletedTask;  
    }  
  
    protected virtual void HandleMessage(string content)  
    {  
        // we just print this message  
        var resultModel = JsonConvert.DeserializeObject<TDataModel>(content);
        handler(resultModel);
        _logger.Information($"consumer received {content}");  
    }  
      
    private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e)  {  }  
    private void OnConsumerUnregistered(object sender, ConsumerEventArgs e) {  }  
    private void OnConsumerRegistered(object sender, ConsumerEventArgs e) {  }  
    private void OnConsumerShutdown(object sender, ShutdownEventArgs e) {  }  
    private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)  {  }  
  
    public override void Dispose()  
    {  
        _channel.Close();  
        _connection.Close();  
        base.Dispose();  
    }  
} 