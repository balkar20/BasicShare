namespace Mod.Auth.Models;

public record UserModel
{
    public string Id { get; init; }
    public int AmountOfPoints { get; init; }
    public string? UserName { get; init; }
    public string? Image { get; init; }
    public string? Description { get; init; }
    public List<string?> Claims { get; init; }

    public void Deconstruct(out string Id, out int AmountOfPoints, out string? UserName, out string? Image, out string? Description, out List<string?> Claims)
    {
        Id = this.Id;
        AmountOfPoints = this.AmountOfPoints;
        UserName = this.UserName;
        Image = this.Image;
        Description = this.Description;
        Claims = this.Claims;
    }
}