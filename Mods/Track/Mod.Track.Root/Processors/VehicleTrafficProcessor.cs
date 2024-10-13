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

public class VehicleTrafficProcessor(IProcessingItemsStorageServiceRepository<string, Track, VehicleTrafficProcessionResult> processingItemsStorageServiceRepository,
    IAnalyzerService analyzerService,
    IMapper mapper,
    IEventLoggingService loggingService, 
    string processorName)
    : ProgressiveProcessor<Track, VehicleTrafficProcessionResult>(loggingService, processorName)
{
    
    // public VehicleTrafficProcessor(ISharedMemoryVehicleService sharedMemoryService,
    //     IVehicleAnalyzerService<IAnalysingResult> vehicleAnalyzerService, 
    //     IMapper mapper) : 
    //     base(sharedMemoryService, vehicleAnalyzerService, mapper)
    // {
    // }

    #region Protected Methods

     protected override async Task<IProcessionResult> ProcessLogic(Track inputData)
        {
            var analysingItem = mapper.Map<TypeAnalysingItem>(inputData);
            var typeAnaliseResult = await analyzerService.Analyse(analysingItem);
            var typeProcessionResult = mapper.Map<VehicleTrafficProcessionResult>(typeAnaliseResult);
            await loggingService.Log($"{ProcessorName} + time {DateTime.Now}", EventLoggingTypes.ProcessedProcessor);
            return typeProcessionResult;
        }

        protected override async Task SetProcessionResult(VehicleTrafficProcessionResult result)
        {
            await processingItemsStorageServiceRepository.CreateProcessingItemResult(result);
        }

        #endregion

   
    #region Private Methods

    private async Task WorkWithDependentData(string trackId)
    {
        // sharedMemoryService.VehicleMarkProcessResultDictionary.TryGetValue(trackId, out VehicleMarkProcessionResult dependentData);
        // Console.WriteLine($"DependentDta(VehicleColorStatistics) Message: {dependentData.Message}");
    }

    #endregion
}