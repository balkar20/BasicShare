using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using EventStore;
using EventStore.Events;

namespace EventTrain;

class AccountRepository
{
    private Store Store { get; }
    private record EventDescriptor(Guid AggregateId, long EventId, string EventData, string User, Guid CorrelationId);
    public void Save(Account account)
    {
        var evts = account.UncommittedEvents.ToList();
        // evts.Select(e =>
        //     new EventDescriptor(account.Id, 0, JsonSerializer.Serialize(e), Environment.UserName, Guid.Empty));
        Store.AddEvents(evts, account.Id);
        
        //_context.Events.AddRange(evts);
        account.Commit();
    }
    
    public Account Load(Guid id)
    {
        //load all evtswhere Aggregate/StreamId = Id
        //_context.Events.Where(e => e.AggregateId == id).OrderBy(o => o.EventId).ToList();
        // var evts = new List<Event>(new Event[]
        // {
        //     new AccountOpened(new Guid(), "jhjh", "kjkjkjkj"),
        //     new MoneyTransfered(new Guid(), 55, "kjkjkjkj"),
        //     new MoneyTransfered(new Guid(), 55, "kjkjkjkj"),
        //     new MoneyTransfered(new Guid(), 55, "kjkjkjkj"),
        //     new MoneyTransfered(new Guid(), 55, "kjkjkjkj")
        // });
        var evts = Store.LoadEvents(id);

        var account = new Account();
        account.Rehydrate(evts);
        
        return account;
    }
    
    
}