

using Core.Base.EventSourcing;

namespace EventStore.Events;

public record AccountOpened : Event
{
    public Guid Id { get; set; }
    private string Owner { get; set; }
    private string Iban { get; set; }

    public AccountOpened(Guid id, string owner, string iban)
    {
        Id = id;
        Owner = owner;
        Iban = iban;
    }
}