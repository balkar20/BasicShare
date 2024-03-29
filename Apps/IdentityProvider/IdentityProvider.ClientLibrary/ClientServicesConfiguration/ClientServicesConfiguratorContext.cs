using System.Globalization;
using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using ClientLibrary.Interfaces.Particular;
using ClientLibrary.Services;
using ClientLibrary.Validators;
using Grpc.Net.Client;
using IdentityProvider.Shared;
using IdentityProvider.Shared.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Microsoft.Extensions.Localization;
using Grpc.Net.Client.Web;

namespace ClientLibrary.ClientServicesConfiguration;

public class ClientServicesConfiguratorContext
{
    #region fieldsof MvvmViewModels

    private readonly IBaseMvvmViewModel<RegisterViewModel> _mvvmRegisterViewModel;
        private readonly IBaseMvvmViewModel<LoginViewModel> _mvvmLoginViewModel;
        private readonly IBaseMvvmViewModel<UserViewModel> _mvvmPooperViewModel;

    #endregion


    private readonly IServiceCollection _services;
    private readonly WebAssemblyHostBuilder _builder;

    public ClientServicesConfiguratorContext(WebAssemblyHostBuilder builder)
    {
        _builder = builder;
        
        _services = builder.Services;
        
        _mvvmRegisterViewModel = new BaseMvvmViewModel<RegisterViewModel>(new RegisterViewModelFluentValidator());
        _mvvmLoginViewModel = new BaseMvvmViewModel<LoginViewModel>(new LoginViewModelFluentValidator());
        _mvvmPooperViewModel = new BaseMvvmViewModel<UserViewModel>(new UserViewModelFluentValidator(), (t, filter) => 
            (string.IsNullOrWhiteSpace(filter.StringValue) || t.UserName.Contains(filter.StringValue))
            && (!filter.Labels.Any() || filter.Labels.Intersect(t.Claims).Any()));
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
        _mvvmPooperViewModel.ConfigureCrudService<UserViewModel>(_services);
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
        _services.AddScoped<IClientOrderCreationService, ClientOrderCreationService>();
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
        _services.AddSingleton(services =>
        {
            var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler())); 
            var baseUri = services.GetRequiredService<NavigationManager>().BaseUri; 
            var channel = GrpcChannel.ForAddress(baseUri, new GrpcChannelOptions { HttpClient = httpClient }); 
            return new CreateOrder.CreateOrderClient(channel); 
        });
    }
}