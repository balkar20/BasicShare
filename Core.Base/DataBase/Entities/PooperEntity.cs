using Core.Base.DataBase.Interfaces;

namespace Core.Base.DataBase.Entities;

public class PooperEntity: IEntity
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public int? AmountOfPoops { get; set; }
}