using AutoMapper;
using ParallelProcessing.Models;
using ParallelProcessing.Models.Items.Analysing;
using ParallelProcessing.Models.Results;
using ParallelProcessing.Models.Results.Procession.Abstractions;
using ParallelProcessing.Processors.Abstractions;
using ParallelProcessing.Services;
using ParallelProcessing.Services.Analysers.Abstractions;
using ParallelProcessing.Services.Events.Abstractions;
using ParallelProcessing.Services.Events.Data.Enums;

namespace ParallelProcessing.Processors;

public class VehicleDangerProcessor(IProcessingItemsStorageServiceRepository<string, Track, VehicleDangerProcessionResult> processingItemsStorageServiceRepository,
    IAnalyzerService analyzerService,
    IMapper mapper,
    IEventLoggingService loggingService, 
    string processorName)
    : ProgressiveProcessor<Track, VehicleDangerProcessionResult>(loggingService, processorName)
{
    protected override async Task<IProcessionResult> ProcessLogic(Track inputData)
    {
        // var vehicles = await _sharedMemoryService.ProcessingItemsStorageService.G(inputData.ItemId);
        var analysingItem = mapper.Map<TypeAnalysingItem>(inputData);
        var typeAnaliseResult = await analyzerService.Analyse(analysingItem);
        var typeProcessionResult = mapper.Map<VehicleDangerProcessionResult>(typeAnaliseResult);
        await loggingService.Log($"{ProcessorName} + time {DateTime.Now}", EventLoggingTypes.ProcessedProcessor);
        return typeProcessionResult;
    }

    protected override async Task SetProcessionResult(VehicleDangerProcessionResult result)
    {
        await processingItemsStorageServiceRepository.CreateProcessingItemResult(result);
    }

    private async Task WorkWithDependentData(string processingItemId)
    {
         // VehicleTypeProcessionResult dependentData = _sharedMemoryService.ProcessingItemsStorageServiceRepository.GetProcessingItem(processingItemId);
         // Console.WriteLine($"DependentDta(VehicleColorStatistics) Message: {dependentData.Message}");
    }
}