using System.Reflection;
using AutoMapper;
using Mod.Order.Base.Mapping;
// using Core.Base.ConfigurationInterfaces;
using Moq;
using Serilog;

namespace EventIntegrationTest;

public class MockServices
{
    // public Mock<IOrderService> ProductServiceMock { get; init; }
    //
    // public Mock<IProductRepository> ProductRepositoryMock { get; init; }
    //
    // public Mock<IProductApiConfiguration> ProductApiConfigurationMock { get; init; }

    public Mock<ILogger> Logger { get; init; }
    public MockServices()
    {
        // ProductServiceMock = new Mock<IProductService>();
        // ProductRepositoryMock = new Mock<IProductRepository>();
        // ProductApiConfigurationMock = new Mock<IProductApiConfiguration>();
        
        // var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<OrderEventObjectDocumentProfile>());
        // var mapperConfiguration1 = new MapperConfiguration(cfg => cfg.AddProfile<OrderEventProfile>());
        // var mapperConfiguration2 = new MapperConfiguration(cfg => cfg.AddProfile<OrderEventSagaMessageProfile>());
        // var mapperConfiguration3 = new MapperConfiguration(cfg => cfg.AddProfile<OrderModelProfile>());
        
        Logger = new Mock<ILogger>();
    }
    
    public IEnumerable<(Type, object)> GetMocks()
    {
        return GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(x =>
            {
                var interfaceType = x.PropertyType.GetGenericArguments()[0];
                var value = x.GetValue(this) as Mock;
                return (interfaceType, value.Object);
            })
            .ToArray();
    }
}