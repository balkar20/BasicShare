using Mod.Order.Models;
using Mod.Order.Models.Enums;
namespace EventIntegrationTest;

public class Randomizer
{
    public string GenerateRandomString()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var randomString = new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return randomString;
    }

    private static readonly Random random = new Random();

    public static OrderModel CreateRandomOrderModel()
    {
        return new OrderModel()
        {
            Id = random.Next(1000000),
            Description = Guid.NewGuid().ToString(),
            OrderType = (OrderType)random.Next(3),
            OrderStatus = (OrderStatus)random.Next(4),
            OrderPayloadId = random.Next(1000000),
            PaymentInfo = new PaymentInfo() { Price = random.Next(1000) },
            Notification = new OrderNotification() { NotificationType = (NotificationType)random.Next(4) },
            CustomerId = Guid.NewGuid().ToString()
        };
    }
}