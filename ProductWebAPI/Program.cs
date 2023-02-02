using Serilog;
using ProductWebApi;
using Serilog.Sinks.GrafanaLoki;

using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("ProductApiTest")]


var credentials = new GrafanaLokiCredentials()
{
    User = "admin",
    Password = "admin"
};
Startup StartupClass;

//Creating the Logger with Minimum Settings
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .Enrich.FromLogContext()
    .Enrich.WithProperty("ALabel", "ALabelValue")
    .WriteTo.GrafanaLoki(
        "http://loki:3100",
        credentials,
        new Dictionary<string, string>() { { "app", "Serilog.Sinks.GrafanaLoki.Sample" } }, // Global labels
        Serilog.Events.LogEventLevel.Debug,
        httpClient: new CustomHttpClient() 
    )
    .CreateLogger();

//try/catch block will ensure any configuration issues are appropriately logged
try
{
    Log.Information("Staring the Host");
    // Log.Information($"Db connection is: {BaseApiEnvironment.DbUrl}");
    
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.AddSerilog(Log.Logger);
    builder.Host.UseSerilog(Log.Logger);

    var startUp = new Startup(builder.Configuration);
    startUp.ConfigureServices(builder.Services);
    
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

public class CustomHttpClient : GrafanaLokiHttpClient
{
    public override async Task<HttpResponseMessage> PostAsync(string requestUri, Stream contentStream)
    {
        using var content = new StreamContent(contentStream);
        content.Headers.Add("Content-Type", "application/json");
        var response = await HttpClient
            .PostAsync(requestUri, content)
            .ConfigureAwait(false);
        return response;
    }
}
