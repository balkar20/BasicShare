using Db.Interfaces;

namespace Db.Entities;

public class Product: IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}