using Core.Base.DataBase.Interfaces;

namespace Core.Base.DataBase.Entities;

public class OrderEntity: IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}