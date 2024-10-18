using AutoMapper;
using Data.Base.Objects;
using EventBus.Messages;
using EventBus.Messages.Interfaces;
using Mod.Track.EventData.Events;

namespace Mod.Track.Base.Mapping;

public class TrackEventSagaMessageProfile: Profile
{
    public TrackEventSagaMessageProfile()
    {
        CreateMap<CreateTrackMessage, TrackCreatedEvent>()
            .ForMember(x=> x.Id, 
                opt => 
                    opt.MapFrom(src => src.TrackId))
            .ForMember(x=> x.CustomerId, 
                opt => 
                    opt.MapFrom(src => src.CustomerId))
            .ForPath(x=> x.TrackPaymentInfoEventModel.Price, 
                opt => 
                    opt.MapFrom(src => src.TotalPrice))
            .ForMember(x=> x.PaymentAccountId, 
                opt => 
                    opt.MapFrom(src => src.PaymentAccountId))
            .ReverseMap();
        CreateMap<EventObject, IBaseSagaMessage>()
            .Include<TrackCreatedEvent, CreateTrackMessage>().ReverseMap();
        CreateMap<EventObject, ICreateTrackMessage>()
            .Include<TrackCreatedEvent, CreateTrackMessage>().ReverseMap();
    }
}