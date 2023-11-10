using AutoMapper;
using Core.Base.ConfigurationInterfaces;
using EventBus.Constants;
using EventBus.Messages.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.MassTransit;
using MassTransit;
using Serilog;

namespace Infrastructure.Services;

public class MessageBusService : IMessageBusService
{
    private readonly IMessageBrokerConfiguration _configuration;
    private readonly ILogger _logger;
    private readonly IBus _bus;

    private readonly IMapper _mapper;

    public MessageBusService(
        IMessageBrokerConfiguration configuration,
        ILogger logger,
        IBus bus, 
        IMapper mapper)
    {
        _configuration = configuration;
        _logger = logger;
        _bus = bus;
        _mapper = mapper;
    }

    public async Task PublishMessage<T>(T message)
    {
        if (message != null)
        {
            dynamic mapped = _mapper.Map<IBaseSagaMessage>(message);
                var queName = $"queue:{QueuesConsts.CreateOrderMessageQueueName}";
                var sep = await _bus.GetSendEndpoint(new Uri($"queue:{QueuesConsts.CreateOrderMessageQueueName}"));
                // dynamic msg = mapped;
                await sep.Send<ICreateOrderMessage>(mapped);
        }
    }
}