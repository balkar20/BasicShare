

namespace EventStore.Events;

public class AccountOpened : Event
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