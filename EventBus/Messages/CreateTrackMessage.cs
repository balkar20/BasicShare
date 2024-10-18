using EventBus.Events;
using EventBus.Messages.Interfaces;

namespace EventBus.Messages;

public class CreateTrackMessage: ICreateTrackMessage
{
    public Guid TrackId { get; set; }
    public string CustomerId { get; set; }
    public string PaymentAccountId { get; set; }
    public decimal TotalPrice { get; set; }
    public List<TrackItem> TrackItemList { get; set; }
}