namespace Data.Ordering.Objects;

public class EventObject: BaseObject
{
    public int Version { get; set; }

    public EventObject(Guid id) : base(id)
    {
    }
}