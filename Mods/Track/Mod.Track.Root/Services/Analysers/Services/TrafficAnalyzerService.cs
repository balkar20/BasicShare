using ParallelProcessing.Configuration;
using ParallelProcessing.Models.Items.Analysing;
using ParallelProcessing.Models.Results.Analyse;
using ParallelProcessing.Models.Results.Analyse.Abstractions;
using ParallelProcessing.Services.Analysers.Abstractions;

namespace ParallelProcessing.Services.Analysers.Services;

class TrafficAnalyzerService(VehicleTrafficAnalyseConfig vehicleTrafficAnalyseConfig) : IAnalyzerService
{
    private  TimeSpan timeForAnalyse = vehicleTrafficAnalyseConfig.TimeForAnalyse;

    public async Task<IAnalysingResult> Analyse(AnalysingItem analysingItem)
    {
        await Task.Delay(timeForAnalyse);
        return new TrafficAnalyseResult
        {
            Message = $"I was Delayed for {timeForAnalyse} by Analysing vehicle Traffic: Number={analysingItem.ItemId} with Traffic=...."
        };
    }
}