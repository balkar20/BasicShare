namespace Mod.CameraModule.Models;

public record CameraModuleModel
{
    public Guid Id { get; init; }
    
    public string? Name { get; init; }
    
    public string?  Description { get; init; }
    
    public decimal?  Price { get; init; }
}