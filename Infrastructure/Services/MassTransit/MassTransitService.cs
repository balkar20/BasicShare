using System.Text.Json;
using Infrastructure.Interfaces.MassTransit;
using MassTransit;

namespace Infrastructure.Services.MassTransit;

public class MassTransitService : IMassTransitService
{
    private readonly ISendEndpointProvider _sendEndpointProvider;
    private readonly IPublishEndpoint _publishEndpoint;

    public MassTransitService(ISendEndpointProvider sendEndpointProvider, IPublishEndpoint publishEndpoint)
    {
        _sendEndpointProvider = sendEndpointProvider;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Send<T>(T message, string queueName) where T : class 
    {
        var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"));

        // var mty = message.GetType().GetInterfaces()[0];
        dynamic newm = message;
        // var seri = JsonSerializer.Serialize(mty);
        await sendEndpoint.Send(message);
    }
    
    public async Task Publish<T>(T message) where T : class
    {
        await _publishEndpoint.Publish<T>(message);
    }
}