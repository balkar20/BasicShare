using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.Track.EventData.Events.Models;
using Mod.Track.Models;
using EventsTrackStatus = Mod.Track.EventData.Enums.TrackStatus;
using EventsTrackNotificationType = Mod.Track.EventData.Enums.NotificationType;
using EventsTrackType = Mod.Track.EventData.Enums.TrackType;
using TrackModelCustomerInfo = Mod.Track.Models.CustomerInfo;
using TrackModelTrackStatus = Mod.Track.Models.Enums.TrackStatus;
using TrackModelNotificationType = Mod.Track.Models.Enums.NotificationType;
using TrackModelTrackType = Mod.Track.Models.Enums.TrackType;

namespace Mod.Track.Base.Mapping;

public class TrackEventProfile: Profile
{
    public TrackEventProfile()
    {
        CreateMap<TrackModel, TrackEntity>().ReverseMap();
        
        CreateMap<TrackModel, TrackCreationDataModel>()
            .ForMember(o => o.Description, 
                m => 
                    m.MapFrom(k => k.Description))
            .ForMember(o => o.TrackType, 
                m => 
                    m.MapFrom(k => k.TrackType))
            .ForMember(o => o.TrackPayloadId, 
                m => 
                    m.MapFrom(k => k.TrackPayloadId))
            .ForMember(o => o.TrackPaymentInfoEventModel, 
                m => 
                    m.MapFrom(k => k.TrackPaymentInfoModel))
            .ForMember(o => o.NotificationEventModel, 
                m => 
                    m.MapFrom(k => k.NotificationModel))
            .ForMember(o => o.CustomerId, 
                m => 
                    m.MapFrom(k => k.CustomerId))
            .ReverseMap();
        
        // CreateMap<TrackModel, TrackCreationDataModel>()
        //     .ForCtorParam(ctorParamName: "Description", 
        //         m => 
        //             m.MapFrom(k => k.Description))
        //     .ForCtorParam(ctorParamName: "TrackType", 
        //         m => 
        //             m.MapFrom(k => k.TrackType))
        //     .ForCtorParam(ctorParamName: "TrackPayloadId", 
        //         m => 
        //             m.MapFrom(k => k.TrackPayloadId))
        //     .ForCtorParam(ctorParamName: "PaymentInfo", 
        //         m => 
        //             m.MapFrom(k => k.TrackPaymentInfoModel))
        //     .ForCtorParam(ctorParamName: "Notification", 
        //         m => 
        //             m.MapFrom(k => k.NotificationModel))
        //     .ForCtorParam(ctorParamName: "CustomerId", 
        //         m => 
        //             m.MapFrom(k => k.CustomerId))
        //     .ReverseMap();
        
        CreateMap<TrackPaymentInfoEventModel, TrackPaymentInfoModel>().ReverseMap();
        CreateMap<CustomerInfoEventModel, TrackModelCustomerInfo>().ReverseMap();
        CreateMap<TrackNotificationEventModel, TrackNotificationModel>().ReverseMap();
        CreateMap<EventsTrackStatus, TrackModelTrackStatus>().ReverseMap();
        CreateMap<EventsTrackType, TrackModelTrackType>().ReverseMap();
        CreateMap<EventsTrackNotificationType, TrackModelNotificationType>().ReverseMap();
    }
}