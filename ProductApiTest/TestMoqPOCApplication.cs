using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProductApiTest;

internal class TestMoqPOCApplication: WebApplicationFactory<Program>
{
    private readonly MockServices _mockServices;
    
    private readonly Dictionary<Type, object> TypeImplementaitionDictionary;

    public TestMoqPOCApplication(MockServices mockServices)
    {
        _mockServices = mockServices;
        TypeImplementaitionDictionary = new Dictionary<Type, object>();
    }
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services => {
            
            foreach ((var interfaceType, var serviceMock) in _mockServices.GetMocks())
            {
                var service = services.SingleOrDefault(d => d.ServiceType == interfaceType);
                services.Remove(service);
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