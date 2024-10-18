// using AutoMapper;
// using Core.Transfer;
// using Data.Base.Objects;
// using EventBus.Constants;
// using EventBus.Messages;
// using EventBus.Messages.Interfaces;
// using Infrastructure.Interfaces;
// using Infrastructure.Interfaces.MassTransit;
// using MassTransitBase;
// using MediatR;
// using Mod.Track.Base.Commands;
// using Mod.Track.EventData.Enums;
// using Mod.Track.EventData.Events;
// using Mod.Track.Interfaces;
//
// namespace Mod.Track.Base.Handlers;
//
// public class TestCreateTrackCommandHandler: IRequestHandler<CreateTrackCommand, BaseResponseResult>
// {
//     // private readonly ITrackRepository _TrackRepository;
//     private readonly IMassTransitService _massTransitService;
//     private readonly IMapper _mapper;
//
//     // public CreateTrackCommandHandler(ITrackRepository TrackRepository, IRabbitMqProducer rabbitMqProducer)
//     public TestCreateTrackCommandHandler(IMassTransitService massTransitService, IMapper mapper)
//     {
//         // _TrackRepository = TrackRepository;
//         // _messageBusService = messageBusService;
//         // _TrackSevice = TrackSevice;
//         _massTransitService = massTransitService;
//         _mapper = mapper;
//     }
//
//     public async Task<BaseResponseResult> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
//     {
//         var result = new BaseResponseResult()
//         {
//             IsSuccess = false
//         };
//         
//         result.IsSuccess = true;
//         var TrackCreatedEvent = new TrackCreatedEvent()
//         {
//             CustomerId = "kjkjkj",
//             TrackType = TrackType.Product,
//             PaymentAccountId = 1,
//             Version = 2
//         };
//         var mapped = _mapper.Map<IBaseSagaMessage>(TrackCreatedEvent);
//         var random = new Random();
//         var message = new CreateTrackMessage()
//         {
//             TrackId = Guid.NewGuid(),
//             CustomerId = random.Next(1, 10000).ToString(),
//             PaymentAccountId = random.Next(1, 10000).ToString(),
//             TotalPrice = 50
//         };
//         
//         var mapped2 = _mapper.Map<IBaseSagaMessage>(message);
//         // var mty = mapped2.GetType();
//         // var mapped3 = _mapper.Map(message, mty);
//         var o = mapped switch
//         {
//             ICreateTrackMessage create => create,
//             _ => mapped
//         };
//         
//         ICreateTrackMessage? createTrackMessage = mapped as ICreateTrackMessage;
//         await _massTransitService.Send(mapped2, QueuesConsts.CreateTrackMessageQueueName);
//         // result.IsSuccess = true;
//
//         
//         return result;
//     }
// }