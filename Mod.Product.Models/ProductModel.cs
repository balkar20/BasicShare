namespace Mod.Product.Models;

public record ProductModel
{
    public string Id { get; init; }
    
    public string? BusinessChannelAlias { get; init; }
    
    public string?  ProductAlias{ get; init; }
}