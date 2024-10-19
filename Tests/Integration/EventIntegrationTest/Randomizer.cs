using Microsoft.EntityFrameworkCore.Storage;
using Mod.Order.Models;
using Mod.Order.Models.Enums;
using Mod.Product.Models;
using RandomNameGeneratorLibrary;

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
    private static readonly PersonNameGenerator personNameGenerator = new ();
    private static readonly ParameterNameGenerator parameterNameGenerator = new ();

    public static OrderModel CreateRandomOrderModel()
    {
        return new OrderModel()
        {
            Id = Guid.NewGuid(),
            Description = Guid.NewGuid().ToString(),
            OrderType = (OrderType)random.Next(3),
            OrderStatus = (OrderStatus)random.Next(4),
            OrderPayloadId = Guid.NewGuid(),
            OrderPaymentInfoModel = new OrderPaymentInfoModel() { Price = 50 },
            NotificationModel = new OrderNotificationModel() { NotificationType = (NotificationType)random.Next(4) },
            CustomerId = Guid.NewGuid()
        };
    }
    public static ProductModel CreateRandomProductModel()
    {
        return new ProductModel()
        {
            Description = parameterNameGenerator.GenerateNext(),
            Name = parameterNameGenerator.GenerateNext()
        };
    }
}