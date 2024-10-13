using AutoMapper;
using Infrastructure.Interfaces;
using Mod.Track.EventData.Aggregates;
using Mod.Track.EventData.Events;
using Mod.Track.EventData.Events.Models;
using Mod.Track.Interfaces;
using Mod.Track.Models;

namespace Mod.Track.Services;

public class TrackWriteService: ITrackWriteService
{
    private readonly IAggregateRepository<TrackAggregate> _oerderAggregateRepository;
    protected readonly IMapper _mapper;
    

    public TrackWriteService(IMapper mapper, IAggregateRepository<TrackAggregate> oerderAggregateRepository)
    {
        _mapper = mapper;
        _oerderAggregateRepository = oerderAggregateRepository;
    }

    public async Task UpdateTrackNotification(TrackNotificationModel orderNotificationModel)
    {
        var notificationEventModel = _mapper.Map<TrackNotificationEventModel>(orderNotificationModel);
        var orderAggregate = await _oerderAggregateRepository.GetById(orderNotificationModel.TrackId);
        orderAggregate.UpdateNotification(notificationEventModel);
        await _oerderAggregateRepository.Save(orderAggregate, -1);
    }

    public async Task UpdateTrackPaymentInfo(TrackPaymentInfoModel orderNotificationModel)
    {
        var paymentInfoEventModel = _mapper.Map<TrackPaymentInfoEventModel>(orderNotificationModel);
        var orderAggregate = await _oerderAggregateRepository.GetById(orderNotificationModel.TrackId);
        orderAggregate.UpdatePaymentInfo(paymentInfoEventModel);
        await _oerderAggregateRepository.Save(orderAggregate, -1);
    }

    public async Task<TrackIdModel> CreateTrack(TrackModel order)
    {
        var creationData = _mapper.Map<TrackCreationDataModel>(order);
        var aggregate = new TrackAggregate(creationData);
        var model = new TrackIdModel
        {
            Version = await _oerderAggregateRepository.Save(aggregate, -1),
            TrackId = aggregate.Id
        };
        return model;
    }
}