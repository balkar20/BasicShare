namespace Mod.Order.Models;

public class OrderIdModel
{
    public Guid OrderId { get; set; }
    
    public int? Version { get; set; }
}