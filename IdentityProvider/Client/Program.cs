using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using ClientLibrary.Interfaces.Particular;
using ClientLibrary.Iterceptors;
using ClientLibrary.Services;
using Core.Transfer;
using IdentityProvider.Client;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Castle.DynamicProxy;
using ClientLibrary.Validators;
using FluentValidation;
using IdentityProvider.Shared.Interfaces;


//using Mod.Auth.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var services = builder.Services;

services.AddOptions();
services.AddBlazoredLocalStorage();
services.AddAuthorizationCore();
services.AddScoped<AuthStateProvider>();
services.AddMudServices();



// services.AddSingleton<MvvmInterceptor<PooperViewModel>>();
// services.AddSingleton<MvvmInterceptor<LoginViewModel>>();
IBaseMvvmViewModel<PooperViewModel> mvvmPooperViewModel = new BaseMvvmViewModel<PooperViewModel>();
mvvmPooperViewModel.DataApiString = "api/pooper";
mvvmPooperViewModel.DataListApiString = "api/poopers";
services.AddSingleton<
    IBaseCrudService<PooperViewModel, BaseResponseResult, PooperViewModel>, 
    BaseCrudService<PooperViewModel, BaseResponseResult, PooperViewModel>>();

// services.AddSingleton(o =>
// {
//     var interceptor = new MvvmInterceptor<PooperViewModel>(mvvmPooperViewModel);
//     var proxyGenerator = new ProxyGenerator();
//     var viewModel = mvvmPooperViewModel;
//     var proxy = proxyGenerator.CreateInterfaceProxyWithTarget(typeof(IBaseMvvmViewModel<PooperViewModel>), viewModel, interceptor);
//     return (IBaseMvvmViewModel<PooperViewModel>)proxy;
// });

services.AddSingleton<AbstractValidator<PooperViewModel>, PooperViewModelFluentValidator>();
services.AddSingleton<AbstractValidator<LoginViewModel>, LoginViewModelFluentValidator>();

services.AddSingleton(mvvmPooperViewModel);
IBaseMvvmViewModel<LoginViewModel> mvvmLoginViewModel = new BaseMvvmViewModel<LoginViewModel>();
mvvmPooperViewModel.DataApiString = "api/pooper";
mvvmPooperViewModel.DataListApiString = "api/poopers";
services.AddSingleton(mvvmLoginViewModel);
// services.AddSingleton<IBaseMvvmViewModel<LoginViewModel>>( o =>
// {
//     var interceptor =  new MvvmInterceptor<LoginViewModel>(mvvmLoginViewModel);
//     var proxyGenerator = new ProxyGenerator();
//     var viewModel = mvvmLoginViewModel;
//     var proxy = proxyGenerator.CreateInterfaceProxyWithTarget(typeof(IBaseMvvmViewModel<LoginViewModel>), viewModel, interceptor);
//     return (IBaseMvvmViewModel<LoginViewModel>)proxy;
// });
services.AddSingleton<
    IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel>, 
    BaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel>>();
// services.AddSingleton<IPooperViewModel, PooperVM>();
// services.AddScoped<TokenProvider>();
services.AddSingleton<IAuthenticationService, AuthenticationService>();

services.AddScoped<AuthenticationStateProvider>( o => o.GetRequiredService<AuthStateProvider>());

services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();

