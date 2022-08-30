using System.Reflection;
using System.Text.Json;

namespace EventTrain;

class AccountRepository
{
    private record EventDescriptor(Guid AggregateId, long EventId, string EventData, string User, Guid CorrelationId);
    public void Save(Account account)
    {
        var evts = account.UncommittedEvents.ToList();
        evts.Select(e =>
            new EventDescriptor(account.Id, e, JsonSerializer.Serialize(e), Environment.UserName, Guid.Empty));
        
        
        //_context.Events.AddRange(evts);
        account.Commit();
    }
    
    public Account Load(Guid id)
    {
        //load all evtswhere Aggregate/StreamId = Id
        //_context.Events.Where(e => e.AggregateId == id).OrderBy(o => o.EventId).ToList();
        var evts = new List<IEvent>(new IEvent[]
        {
            new AccountOpened(new Guid(), "jhjh", "kjkjkjkj"),
            new MoneyTransfered(new Guid(), 55, "kjkjkjkj"),
            new MoneyTransfered(new Guid(), 55, "kjkjkjkj"),
            new MoneyTransfered(new Guid(), 55, "kjkjkjkj"),
            new MoneyTransfered(new Guid(), 55, "kjkjkjkj")
        });

        var account = new Account();
        account.Rehydrate(evts);
        
        return account;
    }
    
    
}

public class Account
{
    public Guid Id { get; private set; }
    public ICollection<IEvent> UncommittedEvents { get; } = new List<IEvent>();

    public void Commit() => UncommittedEvents.Clear();

    private enum State
    {
        NotSet,
        Opened,
        Closed
    }

    private State CurrentState { get; set; } = State.NotSet;

    public void Rehydrate(ICollection<IEvent> events)
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

public class MoneyTransfered : IEvent
{
    public decimal Amount { get; set; }

    public MoneyTransfered(object id, decimal amount, string iban)
    {
        throw new NotImplementedException();
    }
}

public class AccountOpened : IEvent
{
    private Guid Id { get; set; }
    private string Owner { get; set; }
    private string Iban { get; set; }

    public AccountOpened(Guid id, string owner, string iban)
    {
        Id = id;
        Owner = owner;
        Iban = iban;
    }
}

public interface IEvent
{
}