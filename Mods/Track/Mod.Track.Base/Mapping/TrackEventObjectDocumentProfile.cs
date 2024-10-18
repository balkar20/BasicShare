using AutoMapper;
using Data.Base.Objects;
using Mod.Track.EventData.Events;
using Mod.Track.EventData.Events.Models;
using TrackingObjects.Track;

using ObjectTrackNotification = TrackingObjects.Track.TrackNotification;
using ObjectTrackPaymentInfo = TrackingObjects.Track.PaymentInfo;
using ObjectTrackCustomerInfo = TrackingObjects.Track.CustomerInfo;
using ObjectTrackType = TrackingObjects.Track.Enums.TrackType;
using ObjectTrackStatus = TrackingObjects.Track.Enums.TrackStatus;
using ObjectTrackNotificationType = TrackingObjects.Track.Enums.NotificationType;
using DocumentTrackType = Mod.Track.EventData.Enums.TrackType;
using DocumentTrackStatus = Mod.Track.EventData.Enums.TrackStatus;
using DocumentTrackNotificationType = Mod.Track.EventData.Enums.NotificationType;

namespace Mod.Track.Base.Mapping;

public class TrackEventObjectDocumentProfile : Profile
{
    public TrackEventObjectDocumentProfile()
    {
        CreateMap<EventObject, EventDocument>()
            .Include<TrackCreatedEvent, TrackCreatedDocument>();
        CreateMap<TrackCreatedEvent, TrackCreatedDocument>().ReverseMap();
        
        CreateMap<ObjectTrackNotification, TrackNotificationEventModel>().ReverseMap();
        CreateMap<ObjectTrackPaymentInfo, TrackPaymentInfoEventModel>().ReverseMap();
        CreateMap<ObjectTrackCustomerInfo, CustomerInfoEventModel>().ReverseMap();
        CreateMap<ObjectTrackType, DocumentTrackType>().ReverseMap();
        CreateMap<ObjectTrackStatus, DocumentTrackStatus>().ReverseMap();
        CreateMap<ObjectTrackNotificationType, DocumentTrackNotificationType>().ReverseMap();
    }
}