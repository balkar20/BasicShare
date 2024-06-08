namespace Mod.PowerSupply.Models;

public record PowerSupplyModel
{
    public Guid Id { get; init; }
    
    public string? Name { get; init; }
    
    public string?  Description { get; init; }
    
    public decimal?  Price { get; init; }
}