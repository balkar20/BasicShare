namespace Core.Base.EventSourcing;

public abstract class AggregateRoot
{
    private readonly List<Event> _changes = new();
    
    public abstract Guid  Id { get; }
}

public class Event
{
    
}