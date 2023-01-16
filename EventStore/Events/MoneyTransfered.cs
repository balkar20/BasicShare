namespace EventStore.Events;

public class MoneyTransfered : Event
{
    public decimal Amount { get; set; }

    public MoneyTransfered(object id, decimal amount, string iban)
    {
        throw new NotImplementedException();
    }
}