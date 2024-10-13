using System.Collections.Concurrent;
using AutoMapper;
using ParallelProcessing.Configuration;
using ParallelProcessing.Consumers;
using ParallelProcessing.Consumers.Abstractions;
using ParallelProcessing.Contexts;
using ParallelProcessing.Producers;
using ParallelProcessing.Producers.Abstraction;
using ParallelProcessing.Root.Abstractions;
using Microsoft.Extensions.Configuration;
using Serilog;
using ParallelProcessing.ClientDevices.Abstractions;
using ParallelProcessing.ClientDevices.Devices;
using ParallelProcessing.Mapping;
using ParallelProcessing.Models;
using ParallelProcessing.Models.Results;
using ParallelProcessing.Processors.Abstractions;
using ParallelProcessing.Processors.Template;
using ParallelProcessing.Services.Events.Services;


namespace ParallelProcessing.Root;

public class TrafficControlStartupConfigurator : StartupConfigurator
{
    private ApplicationConfiguration applicationConfiguration;
    private TrafficProcessingContext _context;
    
    private ITrackConsumer _trackConsumer;
    private ITrackProducer _trackProducer;
    private IMapper _mapper;
    private ITrackDevice _trackDevice;
    private ILogger _logger;

    public TrafficControlStartupConfigurator()
    {
        _trackDevice = new TrackDevice();
        Configure();
    }
    
    public override async Task Run()
    {
        // _context.VehicleRootProcessor.NestedProcessingCompletedEvent += RootProcessorOnNestedProcessingCompleted;
        await new TrafficFlowProcessStarter(
                _trackDevice, 
                _trackProducer,
                _trackConsumer, 
                applicationConfiguration)
            .StartProcess();
    }
    
    public  async Task Test()
    {
        var bunch =  await _trackDevice.GiveMeTrackDataBunch("Type", applicationConfiguration.MaxParallelConsumeCount);
        // _context.VehicleRootProcessor.NestedProcessingCompletedEvent += RootProcessorOnNestedProcessingCompleted;
        foreach (var bunchTrack in bunch.Tracks)
        {
            await _context.VehicleRootProcessor.ProcessNextAsync(bunchTrack);
        }
    }

    protected override void CreateConfiguration()
    {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json", optional: false);
        // .(Directory.GetCurrentDirectory())
        // .AddJsonFile("config.json", optional: false);

        IConfiguration config = builder.Build();
        //Create AppConfiguration
        //todo Make it deserialized from IConfiguration
        applicationConfiguration = new ApplicationConfiguration()
        {
            BoundedCapacity = 100,
            ProduceSpeed = TimeSpan.FromSeconds(0.5),
            MaxParallelConsumeCount = 6,
            ConsumeSpeed = TimeSpan.FromSeconds(2),
            PropagateCompletion = true,
            VehicleTypeAnalyseConfig = new()
            {
                TimeForAnalyse = TimeSpan.FromSeconds(2),
            },
            VehicleColorAnalyseConfig = new()
            {
                TimeForAnalyse = TimeSpan.FromSeconds(2),
            },
            VehicleSeasonAnalyseConfig = new()
            {
                TimeForAnalyse = TimeSpan.FromSeconds(2),
            },
            VehicleTrafficAnalyseConfig = new()
            {
                TimeForAnalyse = TimeSpan.FromSeconds(2),
            },
            VehicleDangerAnalyseConfig = new()
            {
                TimeForAnalyse = TimeSpan.FromSeconds(2),
                // TimeForAnalyse = TimeSpan.FromSeconds(30),
            },
            VehicleMarkAnalyseConfig = new()
            {
                TimeForAnalyse = TimeSpan.FromSeconds(2),
                // TimeForAnalyse = TimeSpan.FromSeconds(30),
            }
        };
    }

    protected override void ConfigureProducers()
    {
        _trackProducer = new TrackProducer(_trackDevice, applicationConfiguration);
    }

    protected override void ConfigureConsumers()
    {
        _trackConsumer = new TrackConsumer(applicationConfiguration, _context, ConfigureDependentProcessors);
    }

    protected override void ConfigureMapping()
    {
        MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new TrackProcessingMappingProfile());  //mapping between Web and Business layer objects// mapping between Business and DB layer objects
        });
        _mapper = config.CreateMapper();
    }

    protected override TrafficProcessingContext ConfigureDependentProcessors()
    {
        _context =  new TestCasesConfiguration().ConfigureDependentProcessorsCase1(applicationConfiguration, _logger, _mapper);
        return _context;
    }
    
    protected override void ConfigureLogging()
    {
        // var credentials = new GrafanaLokiCredentials()
        // {
        //     User = "admin",
        //     Password = "admin"
        // };
        // _logger = new Serilog.Configuration.
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .Enrich.WithProperty("ALabel", "ALabelValue")
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Hour)
            .WriteTo.Console()
            .CreateLogger();
            // .WriteTo.GrafanaLoki(
            //     "http://localhost:3100",
            //     credentials,
            //     new Dictionary<string, string>() { { "app", "Serilog.Sinks.GrafanaLoki.ProductWebApi" } }, // Global labels
            //     Serilog.Events.LogEventLevel.Debug
            // )
            // .CreateLogger();
        _logger = Log.Logger;
    }

    
}