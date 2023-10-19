using AutoMapper;
using Core.Base.ConfigurationInterfaces;
using EventBus.Constants;
using EventBus.Messages.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.MassTransit;
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
        // _massTransitService = massTransitService;
    }

    public async Task PublishMessage<T>(T message)
    {
        if (message != null)
        {
            try
            {
                var mapped = _mapper.Map<IBaseSagaMessage>(message);
                // var mappedInterface = mapped.GetType().GetInterface($"I{mapped.GetType().Name}");
                // ICreateOrderMessage castedObject = mapped as ICreateOrderMessage;
                    // castedObject
                    // var f = 
                    // Now you can use the 'castedObject' with the dynamically obtained interface type
                    // ...
                // var f = mapped as mappedInterface;
                // var maaped = _mapper.Map<IBaseSagaMessage>(message);
                // await _massTransitService.Send<ICreateOrderMessage>(maaped, QueuesConsts.CreateOrderMessageQueueName);
                var queName = $"queue:{QueuesConsts.CreateOrderMessageQueueName}";
                var sep = await _bus.GetSendEndpoint(new Uri($"queue:{QueuesConsts.CreateOrderMessageQueueName}"));
                // var sep2 = await _bus.GetSendEndpoint(new Uri($"queue:{QueuesConsts.CreateOrderMessageQueueName}"));
                await sep.Send<ICreateOrderMessage>(mapped);
                // await sep.Send<ICreateOrderMessage>(castedObject);
                // await sep.Send(castedObject, typeof(ICreateOrderMessage));
                
                // await sep.
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}