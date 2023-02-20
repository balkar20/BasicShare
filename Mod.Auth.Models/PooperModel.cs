namespace Mod.Auth.Models;

public record PooperModel
{
    public string Id { get; init; }
    public int AmountOfPoops { get; init; }
    public string? PooperAlias { get; init; }
    public string? Image { get; init; }
    public string? Description { get; init; }
    public List<string?> Claims { get; init; }

    public void Deconstruct(out string Id, out int AmountOfPoops, out string? PooperAlias, out string? Image, out string? Description, out List<string?> Claims)
    {
        Id = this.Id;
        AmountOfPoops = this.AmountOfPoops;
        PooperAlias = this.PooperAlias;
        Image = this.Image;
        Description = this.Description;
        Claims = this.Claims;
    }
}