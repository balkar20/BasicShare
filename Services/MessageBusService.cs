using AutoMapper;
using Core.Base.ConfigurationInterfaces;
using Infrastructure.Interfaces;
using MassTransit;
using MassTransitBase;
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
        if (message != null)
        {
            var maaped = _mapper.Map<IBaseSagaMessage>(message);
            await _bus.Publish(maaped);
        }
    }
}