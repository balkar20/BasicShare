using Data.Base.Objects;
using TrackingObjects.Track.Enums;

namespace TrackingObjects.Track;

public class TrackCreatedDocument: EventDocument
{
        public TrackCreatedDocument(string Description, TrackType TrackType, long TrackProductId, PaymentInfo PaymentInfo, TrackNotification Notification, CustomerInfo CustomerInfo)
        {
            Id = Guid.NewGuid();
            this.Description = Description;
            this.TrackType = TrackType;
            this.TrackProductId = TrackProductId;
            this.PaymentInfo = PaymentInfo;
            this.Notification = Notification;
            this.CustomerInfo = CustomerInfo;
        }

        public TrackCreatedDocument()
        {
            
        }

        public string Description { get; init; }
        public TrackType TrackType { get; init; }
        
        public TrackStatus TrackStatus { get; init; }
        public long TrackProductId { get; init; }
        public PaymentInfo PaymentInfo { get; init; }
        public TrackNotification Notification { get; init; }
        public CustomerInfo CustomerInfo { get; init; }

        public void Deconstruct(out string Description, out TrackType TrackType, out long TrackProductId, out PaymentInfo PaymentInfo, out TrackNotification Notification, out CustomerInfo CustomerInfo)
        {
            Description = this.Description;
            TrackType = this.TrackType;
            TrackProductId = this.TrackProductId;
            PaymentInfo = this.PaymentInfo;
            Notification = this.Notification;
            CustomerInfo = this.CustomerInfo;
        }
}

