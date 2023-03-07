using Blazored.LocalStorage;
using ClientLibrary.Interfaces;
using ClientLibrary.Interfaces.Particular;
using ClientLibrary.Services;
using Core.Transfer;
using IdentityProvider.Client;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ClientLibrary.Validators;
using FluentValidation;


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

IBaseMvvmViewModel<PooperViewModel> mvvmPooperViewModel = new BaseMvvmViewModel<PooperViewModel>();
mvvmPooperViewModel.DataApiString = "api/pooper";
mvvmPooperViewModel.DataListApiString = "api/poopers";
services.AddSingleton<
    IBaseCrudService<PooperViewModel, BaseResponseResult, PooperViewModel>, 
    BaseCrudService<PooperViewModel, BaseResponseResult, PooperViewModel>>();

services.AddSingleton<
    IBaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel>, 
    BaseCrudService<LoginViewModel, BaseResponseResult, LoginResponseViewModel>>();

services.AddSingleton<AbstractValidator<PooperViewModel>, PooperViewModelFluentValidator>();
services.AddSingleton<AbstractValidator<LoginViewModel>, LoginViewModelFluentValidator>();

services.AddSingleton(mvvmPooperViewModel);
IBaseMvvmViewModel<LoginViewModel> mvvmLoginViewModel = new BaseMvvmViewModel<LoginViewModel>();
mvvmLoginViewModel.DataApiString = "api/login";
services.AddSingleton(mvvmLoginViewModel);

services.AddScoped<IAuthenticationService, AuthenticationService>();

services.AddScoped<AuthenticationStateProvider>( o => o.GetRequiredService<AuthStateProvider>());

services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();

