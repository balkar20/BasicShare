namespace Mod.Order.Models;

public class OrderItemModel
{
    public Guid ProductId { get; set; }
    
    public int Count { get; set; }
}