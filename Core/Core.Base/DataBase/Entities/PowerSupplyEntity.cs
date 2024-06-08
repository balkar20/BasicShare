using Core.Base.DataBase.Interfaces;

namespace Core.Base.DataBase.Entities;

public class PowerSupplyEntity: IEntity
{
    public Guid Id { get; set; } 
    public string? Name { get; set; }
    public string? Description { get; set; }
}

// public class PowerSupplyEntity: AggregateRoot
// {
//     public string? Name { get; set; }
//     public string? Description { get; set; }
//     public override Guid Id { get; }
//
//     private void Apply(PowerSupplyCreated e)
//     {
//         
//     }
// }
