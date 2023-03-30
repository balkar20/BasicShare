namespace Mod.Product.Models;

public record ProductModel
{
    public string Id { get; init; }
    
    public string? Name { get; init; }
    
    public string?  Description { get; init; }
}