using AutoMapper;
using ParallelProcessing.Configuration;
using ParallelProcessing.Models;
using ParallelProcessing.Models.Results;
using ParallelProcessing.Processors;
using ParallelProcessing.Processors.Abstractions;
using ParallelProcessing.Services;
using ParallelProcessing.Services.Analysers.Abstractions;
using ParallelProcessing.Services.Analysers.Services;
using ParallelProcessing.Services.Events.Abstractions;
using ParallelProcessing.Services.Storage.Services;

namespace ParallelProcessing.Contexts;

public class TrafficProcessingContext(ApplicationConfiguration applicationConfiguration)
{
    public  IEventLoggingService EventLogger{ get; private set; }

    #region Processors

    public IProgressiveProcessor<Track> VehicleRootProcessor { get; set; }
    public IProgressiveProcessor<Track> VehicleMarkProcessor { get; set; }
    public IProgressiveProcessor<Track> VehicleColorProcessor { get; set; }
    public IProgressiveProcessor<Track> VehicleSeasonProcessor { get; set; }
    public IProgressiveProcessor<Track> VehicleDangerProcessor { get; set; }
    public IProgressiveProcessor<Track> VehicleTrafficProcessor { get; set; }

    #endregion

    #region Public Methods

    public void InitializeProcessors(ApplicationConfiguration configuration, IMapper mapper, IEventLoggingService logger)
    {
        EventLogger = logger;
        var analysers = GetAnalysers();
        var repositories = GetRepositories();
        VehicleRootProcessor = new VehicleTypeProcessor(repositories.vehicleTypeRepository, analysers.vehicleTypeAnalyzerService, mapper, logger, "FirstTypeProcessor");
        // VehicleRootProcessor.SubscribeToNestedCompletion(async () => Console.WriteLine("pppppppppppppppppppppppppppppppppppp"));
        VehicleSeasonProcessor = new VehicleSeasonProcessor(repositories.seasonRepository, analysers.seasonAnalyzerService, mapper, logger, "FirstSeasonProcessor");
        VehicleColorProcessor = new VehicleColorProcessor(repositories.colorRepository, analysers.colorAnalyzerService, mapper, logger, "FirstColorProcessor");
        VehicleMarkProcessor = new VehicleMarkProcessor(repositories.markRepository, analysers.markAnalyzerService, mapper, logger, "FirstMarkProcessor");
        VehicleTrafficProcessor = new VehicleTrafficProcessor(repositories.trafficRepository, analysers.trafficAnalyzerService, mapper, logger, "FirstTrafficProcessor");
        VehicleDangerProcessor = new VehicleDangerProcessor(repositories.dangerRepository, analysers.dangerAnalyzerService, mapper, logger, "FirstDangerProcessor");
    }

    #endregion

    #region Private Methods

        
    private (
        IAnalyzerService vehicleTypeAnalyzerService,
        IAnalyzerService colorAnalyzerService,
        IAnalyzerService seasonAnalyzerService,
        IAnalyzerService markAnalyzerService,
        IAnalyzerService trafficAnalyzerService,
        IAnalyzerService dangerAnalyzerService
        ) GetAnalysers()
    {
        return (
            new TypeAnalyzerService(applicationConfiguration.VehicleTypeAnalyseConfig),
            new ColorAnalyzerService(applicationConfiguration.VehicleColorAnalyseConfig),
            new SeasonAnalyzerService(applicationConfiguration.VehicleSeasonAnalyseConfig),
            new MarkAnalyzerService(applicationConfiguration.VehicleMarkAnalyseConfig),
            new TrafficAnalyzerService(applicationConfiguration.VehicleTrafficAnalyseConfig),
            new DangerAnalyzerService(applicationConfiguration.VehicleDangerAnalyseConfig));
    }
    
    private (
        IProcessingItemsStorageServiceRepository<String,  Track, VehicleTypeProcessionResult> vehicleTypeRepository,
        IProcessingItemsStorageServiceRepository<String,  Track, VehicleColorProcessionResult> colorRepository,
        IProcessingItemsStorageServiceRepository<String,  Track, VehicleSeasonProcessionResult> seasonRepository,
        IProcessingItemsStorageServiceRepository<String,  Track, VehicleMarkProcessionResult> markRepository,
        IProcessingItemsStorageServiceRepository<String,  Track, VehicleTrafficProcessionResult> trafficRepository,
        IProcessingItemsStorageServiceRepository<String,  Track, VehicleDangerProcessionResult> dangerRepository
        ) GetRepositories()
    {
        var _sharedMemoryStorage = new SharedMemoryStorage();
        return (
            new TypeAbstractDictionaryProcessingItemsStorageServiceRepository(_sharedMemoryStorage),
            new ColorAbstractDictionaryProcessingItemsStorageServiceRepository(_sharedMemoryStorage),
            new SeasonAbstractDictionaryProcessingItemsStorageServiceRepository(_sharedMemoryStorage),
            new MarkAbstractDictionaryProcessingItemsStorageServiceRepository(_sharedMemoryStorage),
            new TrafficAbstractDictionaryProcessingItemsStorageServiceRepository(_sharedMemoryStorage),
            new DangerAbstractDictionaryProcessingItemsStorageServiceRepository(_sharedMemoryStorage));
    }

        
    public async Task<PoolProcessionResult> GetLongRunningTask(Track track)
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
        return new PoolProcessionResult();
    }
    
    #endregion

    
}