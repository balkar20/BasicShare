﻿namespace Mod.MotorControlsModule.Models;

public record MotorControlsModuleModel
{
    public Guid Id { get; init; }
    
    public string? Name { get; init; }
    
    public string?  Description { get; init; }
    
    public decimal?  Price { get; init; }
}