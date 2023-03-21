using Core.Base.DataBase.Interfaces;

namespace Core.Base.DataBase.Entities;

public class PooperEntity: IEntity
{
    public string? Description { get; set; }
    
    public int? AmountOfPoops { get; set; }
    
    public long Id { get; set; }

    public string UserId { get; set; }

    public string? Image { get; set; }
}