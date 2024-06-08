using Core.Base.DataBase.Interfaces;

namespace Core.Base.DataBase.Entities;

public class CameraModuleEntity: IEntity
{
    public Guid Id { get; set; } 
    public string? Name { get; set; }
    public string? Description { get; set; }
}

// public class CameraModuleEntity: AggregateRoot
// {
//     public string? Name { get; set; }
//     public string? Description { get; set; }
//     public override Guid Id { get; }
//
//     private void Apply(CameraModuleCreated e)
//     {
//         
//     }
// }
