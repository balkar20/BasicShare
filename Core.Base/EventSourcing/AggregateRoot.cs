using Data.Base.Objects;

namespace Core.Base.EventSourcing;

public abstract class AggregateRoot
{
    private readonly List<EventObject> _changes = new ();

    public abstract Guid Id { get; }
    public int Version { get; set; }

    public IEnumerable<EventObject> GetUncommittedChanges()
    {
        return _changes;
    }

    public void MarkChangesAsCommitted()
    {
        _changes.Clear();
    }

    public void LoadsFromHistory(IEnumerable<EventObject> history)
    {
        foreach (var e in history) ApplyChange(e, false);
    }

    protected void ApplyChange(EventObject @event)
    {
        ApplyChange(@event, true);
    }

    // push atomic aggregate changes to local history for further processing (EventStore.SaveEvents)
    private void ApplyChange(EventObject @event, bool isNew)
    {
        this.AsDynamic().Apply(@event);
        if(isNew) _changes.Add(@event);
    }
}
