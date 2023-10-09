namespace Data.Ordering.Objects;

public class BaseObject
{
    public BaseObject(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}