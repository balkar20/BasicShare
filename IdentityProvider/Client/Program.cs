using Blazored.LocalStorage;
using IdentityProvider.Client;
using IdentityProvider.Client.ViewModels;
using IdentityProvider.Client.ViewModels.Inerfaces;
using IdentityProvider.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
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

var mvvmViewModel = new BaseMvvmViewModel<string, PooperViewModel>();
mvvmViewModel.DataApiString = "api/pooper";
mvvmViewModel.DataListApiString = "api/poopers";
services.AddSingleton<IBaseMvvmViewModel<string, PooperViewModel>>( o => mvvmViewModel);
services.AddSingleton<IBaseCrudService<PooperViewModel, string>, BaseCrudService<PooperViewModel, string>>();
// services.AddSingleton<IPooperViewModel, PooperVM>();
// services.AddScoped<TokenProvider>();

services.AddScoped<AuthenticationStateProvider>( o => o.GetRequiredService<AuthStateProvider>());

services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();
