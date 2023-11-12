namespace IdentityProvider.Client.Shared;

public class DropDownModel<T>
{
    public string DropDownValue { get; set; }
    public T Data { get; set; }

    public override bool Equals(object o)
    {
        var other = o as DropDownModel<T>;
        return other?.DropDownValue == DropDownValue;
    }

    // Note: this is important too!
    public override int GetHashCode() => DropDownValue?.GetHashCode() ?? 0;

    // Implement this for the Pizza to display correctly in MudSelect
    public override string ToString() => DropDownValue;
}