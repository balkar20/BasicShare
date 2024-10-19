using Core.Base.EventSourcing;
using Mod.Track.EventData.Enums;
using Mod.Track.EventData.Events;
using Mod.Track.EventData.Events.Models;
// using Mod.Track.EventData.Events.Models;

namespace Mod.Track.EventData.Aggregates;

public class TrackAggregate: AggregateRoot
{
    
    private Guid _id;
    
    public override Guid Id
    {
        get { return _id; }
    }

    public TrackAggregate()
    {
        
    }
    public TrackAggregate(Guid id, TrackCreationDataModel model)
    {
        var trackCreatedEvent = new TrackCreatedEvent(
            model.Description,
            model.TrackType,
            model.TrackPayloadId,
            model.TrackPaymentInfoEventModel,
            model.NotificationEventModel,
            model.CustomerId
        );
        
        ApplyChange(trackCreatedEvent);
    }
    
    private void Apply(TrackCreatedEvent e)
    {
        _id = Guid.NewGuid();
        this.Description = e.Description;
        this.TrackType = e.TrackType;
        this.TrackPaymentInfoEventModel = e.TrackPaymentInfoEventModel;
        this.NotificationEventModel = e.NotificationEventModel;
        this.CustomerId = e.CustomerId;
        this.TrackStatus = TrackStatus.Created;
    }
    
    private void Apply(TrackUpdatedEvent e)
    {
        this.Description = e.Description;
        this.TrackPaymentInfoEventModel = e.TrackPaymentInfoEventModel;
        this.NotificationEventModel = e.NotificationEventModel;
        this.CustomerId = e.CustomerId;
        this.TrackStatus = TrackStatus.Updated;
    }
    
    private void Apply(TrackCanceledEvent e)
    {
        this.TrackStatus = TrackStatus.Canceled;
    }
    
    private void Apply(TrackCompletedEvent e)
    {
        this.TrackStatus = TrackStatus.Completed;
    }
    
    private void Apply(TrackUpdatedNotificationEvent e)
    {
        this.NotificationEventModel = e.NotificationEventModel;
    }
    
    private void Apply(TrackUpdatedPaymentInfoEvent e)
    {
        this.TrackPaymentInfoEventModel = e.TrackPaymentInfoEventModel;
    }
    
    public TrackAggregate(TrackCreationDataModel state)
    {
        ApplyChange(new TrackCreatedEvent(state.Description, state.TrackType, state.TrackPayloadId, state.TrackPaymentInfoEventModel, state.NotificationEventModel, state.CustomerId));
    }
    
    public void UpdateNotification(TrackNotificationEventModel state)
    {
        ApplyChange(new TrackUpdatedNotificationEvent(this.Id, state));
    }
    
    public void UpdatePaymentInfo(TrackPaymentInfoEventModel state)
    {
        ApplyChange(new TrackUpdatedPaymentInfoEvent(this.Id, state));
    }
    
    public string Description { get; set; }
    
    public TrackType TrackType { get; set; }

    public long TrackPayloadId { get; set; }
    
    public TrackPaymentInfoEventModel TrackPaymentInfoEventModel { get; set; }
           
    public TrackNotificationEventModel NotificationEventModel { get; set; }
           
    public Guid CustomerId { get; set; }

    public string Track { get; set; }

    public TrackStatus TrackStatus { get; set; }
}