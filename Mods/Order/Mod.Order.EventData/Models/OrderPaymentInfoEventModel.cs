namespace Mod.Order.EventData.Events.Models;

public class OrderPaymentInfoEventModel
{
    public Guid PaymentAccountId { get; set; }
    public decimal Price { get; set; }
}