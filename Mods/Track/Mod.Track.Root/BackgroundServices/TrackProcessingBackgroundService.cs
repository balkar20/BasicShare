using Microsoft.Extensions.Hosting;

namespace ParalleProcessing.BackgroundServices;

public class TrackProcessingBackgroundService: BackgroundService
{
    public TrackProcessingBackgroundService()
    {
        
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}