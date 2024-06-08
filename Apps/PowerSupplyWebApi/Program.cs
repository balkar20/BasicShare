using Serilog;
using System.Runtime.CompilerServices;
using Apps.PowerSupplyWebAPI.Helpers;

[assembly:InternalsVisibleTo("PowerSupplyApiTest")]

try
{
    var builder = WebApplication.CreateBuilder(args);
    // builder.Logging.AddSerilog(Log.Logger);
    // builder.Host.UseSerilog(Log.Logger);

    var startUp = new StartupHelper(builder.Configuration);
    startUp.ConfigureServices(builder);
    var app = builder.Build();
    await startUp.Configure(app, app.Environment);
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

