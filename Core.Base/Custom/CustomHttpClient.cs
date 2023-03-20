using Serilog.Sinks.GrafanaLoki;

namespace Core.Base.Custom;

public class CustomHttpClient: GrafanaLokiHttpClient
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