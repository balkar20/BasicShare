using ClientLibrary.ClientServicesConfiguration;
using IdentityProvider.Client;
using IdentityProvider.Client.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


//using Mod.Auth.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var clientServicesConfiguratorContext = new ClientServicesConfiguratorContext(builder);
clientServicesConfiguratorContext.Configure();

var host = builder.Build();
await host.SetDefaultCulture();
await host.RunAsync();

