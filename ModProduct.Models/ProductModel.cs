namespace ModProduct.Models;

public record ProductModel(string Id, string? BusinessChannelAlias, string? ProductAlias)
{
    public ProductModel() : this("", "", "")
    {
        
    }
}