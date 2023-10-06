using Core.Base.EventSourcing;

namespace EventStore.Events;

public record MoneyTransfered : Event
{
    public decimal Amount { get; set; }

    public MoneyTransfered(object id, decimal amount, string iban)
    {
        throw new NotImplementedException();
    }
}