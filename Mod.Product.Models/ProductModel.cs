namespace Mod.Product.Models;

public record ProductModel
{
    public Guid Id { get; init; }
    
    public string? Name { get; init; }
    
    public string?  Description { get; init; }
    
    public decimal?  Price { get; init; }
}