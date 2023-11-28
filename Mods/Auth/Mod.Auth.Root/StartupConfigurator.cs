using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Mod.Auth.Root.AppServices;
using Mod.Auth.Root.Configuration;
using Mod.Auth.Root.ExtenalServices;

namespace Mod.Auth.Root;

public class StartupConfigurator
{
    private readonly IConfiguration _configuration;
    private readonly WebApplicationBuilder _builder;

    public StartupConfigurator(IConfiguration configuration, WebApplicationBuilder builder)
    {
        _configuration = configuration;
        _builder = builder;
    }

    public void Configure()
    {
        var appServicesConfigurator = new ModAuthServicesConfigurator(_builder.Services);
        var environmentConfigurator = new EnvironmentConfigurator(new AuthEnvironmentContext(_configuration.GetValue<string>));
        var externalServicesConfigurator = new ModAuthExternalServicesConfigurator(environmentConfigurator.AuthEnvironmentContext, _builder);
        
        appServicesConfigurator.Configure();
        environmentConfigurator.ConfigureEnvironment(_builder.Services);
        externalServicesConfigurator.Configure();
    }
}