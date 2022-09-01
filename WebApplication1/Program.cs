using Apps.BaseWebApi.Helpers;
using Core.RabbitMqBase.Interfaces;

var builder = WebApplication.CreateBuilder(args);

StartupHelper.Configure(builder);


var app = builder.Build();
var service = app.Services.GetService<IRabbitMQReader>();
service?.ReadMessage();
StartupHelper.ConfigureServices(app);

