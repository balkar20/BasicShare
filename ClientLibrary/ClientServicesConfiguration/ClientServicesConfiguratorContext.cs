using System.Globalization;
using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using ClientLibrary.Interfaces.Particular;
using ClientLibrary.Services;
using ClientLibrary.Validators;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Microsoft.Extensions.Localization;

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
        ConfigureLocalization();
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

    public void ConfigureLocalization()
    {
        var supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("ru")//you can add more language as you want...
        };
        _services.AddLocalization();
        _services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(supportedCultures[0], supportedCultures[0]);
            options.SupportedUICultures = supportedCultures;
            options.SupportedCultures = supportedCultures;
            CultureInfo.DefaultThreadCurrentCulture = supportedCultures[0];
            CultureInfo.DefaultThreadCurrentUICulture = supportedCultures[0];
        });

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