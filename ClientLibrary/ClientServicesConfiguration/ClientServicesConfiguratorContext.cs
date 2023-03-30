using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using ClientLibrary.Interfaces.Particular;
using ClientLibrary.Services;
using ClientLibrary.Validators;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace ClientLibrary.ClientServicesConfiguration;

public class ClientServicesConfiguratorContext
{
    #region fieldsof MvvmViewModels

    private readonly IBaseMvvmViewModel<RegisterViewModel> _mvvmRegisterViewModel;
        private readonly IBaseMvvmViewModel<LoginViewModel> _mvvmLoginViewModel;
        private readonly IBaseMvvmViewModel<PooperViewModel> _mvvmPooperViewModel;

    #endregion


    private readonly IServiceCollection _services;
    private readonly WebAssemblyHostBuilder _builder;

    public ClientServicesConfiguratorContext(WebAssemblyHostBuilder builder)
    {
        _builder = builder;
        
        _services = builder.Services;
        
        _mvvmRegisterViewModel = new BaseMvvmViewModel<RegisterViewModel>(new RegisterViewModelFluentValidator());
        _mvvmLoginViewModel = new BaseMvvmViewModel<LoginViewModel>(new LoginViewModelFluentValidator());
        _mvvmPooperViewModel = new BaseMvvmViewModel<PooperViewModel>(new PooperViewModelFluentValidator());
    }

    public void Configure()
    {
        ConfigureExternalServices();
        ConfigureAppServices();
        ConfigureMvvmViewModels();
        ConfigureCrudServices();
    }

    public void ConfigureMvvmViewModels()
    {
        _services.AddSingleton(_mvvmRegisterViewModel);
        _services.AddSingleton(_mvvmLoginViewModel);
        _services.AddSingleton(_mvvmPooperViewModel);
    }

    public void ConfigureCrudServices()
    {
        _mvvmRegisterViewModel.ConfigureCrudService<LoginResponseViewModel>(_services);
        _mvvmLoginViewModel.ConfigureCrudService<LoginResponseViewModel>(_services);
        _mvvmPooperViewModel.ConfigureCrudService<PooperViewModel>(_services);
    }

    public void ConfigureAppServices()
    {
        _services.AddScoped<IAuthenticationService, AuthenticationService>();
    }

    public void ConfigureExternalServices()
    {
        _services.AddOptions();
        _services.AddBlazoredLocalStorage();
        _services.AddAuthorizationCore();
        _services.AddScoped<AuthStateProvider>();
        _services.AddMudServices();
        
        _services.AddScoped<AuthenticationStateProvider>( o => o.GetRequiredService<AuthStateProvider>());

        _services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(_builder.HostEnvironment.BaseAddress) });

    }
    
    
}