using System.Collections.Generic;
using EventBus.Events;

namespace EventBus.Messages.Interfaces;

public interface ICreateTrackMessage: IBaseSagaMessage
{
    public Guid TrackId { get; set; }
    public Guid CustomerId { get; set; }
    public string PaymentAccountId { get; set; }
    public decimal TotalPrice { get; set; }
    public List<TrackItem> TrackItemList { get; set; }
}