using EventStore.Events;

namespace EventTrain;

public class Account
{
    public Guid Id { get; private set; }
    public ICollection<Event> UncommittedEvents { get; } = new List<Event>();

    public void Commit() => UncommittedEvents.Clear();

    private enum State
    {
        NotSet,
        Opened,
        Closed
    }

    private State CurrentState { get; set; } = State.NotSet;

    public void Rehydrate(ICollection<Event> events)
    {
        foreach (var evt in events)
        {
            ((dynamic)this).Apply((dynamic)evt);
        }
    }

    public void Apply(AccountOpened evt) => CurrentState = State.Opened;
    public void Apply(MoneyTransfered evt) => CurrentAmount = evt.Amount;

    public void Open(string owner, string Iban)
    {
        UncommittedEvents.Add(new AccountOpened(Id, owner, Iban));
    }

    public void TransferMoney(decimal amount, string iban)
    {
        if (CurrentAmount < amount)
            throw new InvalidOperationException("Not enough money");
        var evt = new MoneyTransfered(Id, amount, iban);
        UncommittedEvents.Add(evt);
        Apply(evt);
    }

    public void Close()
    {
        if (CurrentState != State.Opened)
            throw new InvalidOperationException();
    }


    public decimal CurrentAmount { get; set; }
}