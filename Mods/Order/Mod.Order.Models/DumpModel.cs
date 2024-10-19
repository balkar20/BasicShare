using Mod.Order.Models.Enums;

namespace Mod.Order.Models;

public class DumpModel
{
    public Guid Id { get; set; }
    
    public string Description { get; set; }
    public NotificationType No { get; set; }
}