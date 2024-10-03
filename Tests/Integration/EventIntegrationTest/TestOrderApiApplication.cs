using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// using Program = OrderWebApi;

namespace EventIntegrationTest;

internal class TestOrderApiApplication: WebApplicationFactory<OrderWebAPI.Program>
{
    private readonly MockServices _mockServices;
    
    private readonly Dictionary<Type, object> TypeImplementaitionDictionary;

    public TestOrderApiApplication(MockServices mockServices)
    {
        _mockServices = mockServices;
        TypeImplementaitionDictionary = new Dictionary<Type, object>();
    }
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services => {
            
            foreach ((var interfaceType, var serviceMock) in _mockServices.GetMocks())
            {
                var interfaceServices = services.Where(d => d.ServiceType == interfaceType).ToList();

                foreach (var service in interfaceServices)
                {
                    services.Remove(service);
                }
                
                TypeImplementaitionDictionary.Add(interfaceType, serviceMock);
            }
            
            foreach (var keyValuePair in TypeImplementaitionDictionary)
            {
                Type t = keyValuePair.Key;
                services.AddSingleton(keyValuePair.Key, o => keyValuePair.Value);
            }
        });
        
        return base.CreateHost(builder);
            
    }
}