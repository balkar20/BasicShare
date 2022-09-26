using Apps.Blazor.Identity.IdentityProvider.Server.Helpers;

var builder = WebApplication.CreateBuilder(args);
StartupHelper.ConfigureServices(builder);

var app = builder.Build();
StartupHelper.Configure(app);