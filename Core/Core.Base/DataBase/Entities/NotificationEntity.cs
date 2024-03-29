﻿using Core.Base.DataBase.Interfaces;

namespace Core.Base.DataBase.Entities;

public class NotificationEntity: IEntity
{
    public Guid Id { get; set; } 
    public string? Name { get; set; }
    public string? Description { get; set; }
}

// public class ProductEntity: AggregateRoot
// {
//     public string? Name { get; set; }
//     public string? Description { get; set; }
//     public override Guid Id { get; }
//
//     private void Apply(ProductCreated e)
//     {
//         
//     }
// }