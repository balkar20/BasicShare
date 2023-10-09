using Serilog;
using System.Runtime.CompilerServices;
using Apps.OrderWebAPI.Helpers;

[assembly:InternalsVisibleTo("OrderApiTest")]

try
{
    var builder = WebApplication.CreateBuilder(args);
    // builder.Logging.AddSerilog(Log.Logger);
    // builder.Host.UseSerilog(Log.Logger);

    var startUp = new StartupHelper(builder.Configuration);
    startUp.ConfigureServices(builder);
    
    var app = builder.Build();
    startUp.Configure(app, app.Environment);
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host Terminated Unexpectedly");
}

finally
{
    Log.CloseAndFlush();
}

