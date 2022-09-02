using Apps.BaseWebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

StartupHelper.Configure(builder);

var app = builder.Build();
StartupHelper.ConfigureServices(app);

