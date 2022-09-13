using Apps.Blazor.Identity.IdentityProvider.Server.Helpers;

var builder = WebApplication.CreateBuilder(args);
StartupHelper.Configure(builder);

var app = builder.Build();
StartupHelper.ConfigureServices(app);