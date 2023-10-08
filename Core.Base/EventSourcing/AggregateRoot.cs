using MongoObjects;

namespace Core.Base.EventSourcing;

public abstract class AggregateRoot
{
    private readonly List<EventDocument> _changes = new ();

    public abstract Guid Id { get; }
    public int Version { get; internal set; }

    public IEnumerable<EventDocument> GetUncommittedChanges()
    {
        return _changes;
    }

    public void MarkChangesAsCommitted()
    {
        _changes.Clear();
    }

    public void LoadsFromHistory(IEnumerable<EventDocument> history)
    {
        foreach (var e in history) ApplyChange(e, false);
    }

    protected void ApplyChange(EventDocument @event)
    {
        ApplyChange(@event, true);
    }

    // push atomic aggregate changes to local history for further processing (EventStore.SaveEvents)
    private void ApplyChange(EventDocument @event, bool isNew)
    {
        this.AsDynamic().Apply(@event);
        if(isNew) _changes.Add(@event);
    }
}
