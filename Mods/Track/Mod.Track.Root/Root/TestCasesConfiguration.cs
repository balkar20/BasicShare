using System.Collections.Concurrent;
using AutoMapper;
using Serilog;
using ParallelProcessing.Configuration;
using ParallelProcessing.Contexts;
using ParallelProcessing.Models;
using ParallelProcessing.Models.Results;
using ParallelProcessing.Processors.Abstractions;
using ParallelProcessing.Processors.Template;
using ParallelProcessing.Services.Events.Services;

namespace ParallelProcessing.Root;

public class TestCasesConfiguration
{
    public  TrafficProcessingContext ConfigureDependentProcessorsCase1(ApplicationConfiguration applicationConfiguration,ILogger logger,IMapper mapper)
    {
        var _context = new TrafficProcessingContext(applicationConfiguration);
        
        var loggerService = new EventLoggingService(logger);

        _context.InitializeProcessors(applicationConfiguration, mapper, loggerService);
        
        
        var newProc = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateFirstProcessor", _context.GetLongRunningTask);

        var newProc2 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateSecondProcessor", _context.GetLongRunningTask);
        var newProc3 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateThirdProcessor", _context.GetLongRunningTask);
        var newProc4 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateFourProcessor", _context.GetLongRunningTask);
        //TypeDependant
        _context.VehicleRootProcessor.AddDependentProcessor(_context.VehicleMarkProcessor);
        _context.VehicleRootProcessor.AddDependentProcessor(_context.VehicleDangerProcessor);
        _context.VehicleRootProcessor.AddDependentProcessor(_context.VehicleColorProcessor);
        
       _context.VehicleDangerProcessor.AddDependentProcessor(newProc);
       _context.VehicleDangerProcessor.AddDependentProcessor(newProc2);
       
        _context.VehicleColorProcessor.AddDependentProcessor(_context.VehicleTrafficProcessor);
        _context.VehicleColorProcessor.AddDependentProcessor(_context.VehicleSeasonProcessor);

        _context.VehicleTrafficProcessor.AddDependentProcessor(newProc3);
        _context.VehicleTrafficProcessor.AddDependentProcessor(newProc4);
        
        
        // _context.VehicleSeasonProcessor.AddDependentProcessor(newProc4);
        // //
        // // _context.VehicleDangerProcessor.AddDependentProcessor(newProc);
        // // _context.VehicleDangerProcessor.AddDependentProcessor(newProc2);
        // // _context.VehicleSeasonProcessor.AddDependentProcessor(newProc3);
        //
        //
        // string[] newNames = {"Volvo", "BMW", "Ford"};
        // string[] newNames2 = {"Koko", "Mila", "Oni"};
        // var deps = GetTemplateProcessorsWithNames(newNames, loggerService, _context);
        // var dep2 = GetTemplateProcessorsWithNames(newNames2, loggerService, _context);
        // var depsQueue = new ConcurrentQueue<IProcessor<Track>>(deps);
        // var depsQueue2 = new ConcurrentQueue<IProcessor<Track>>(dep2);
        // newProc2.SetDependents(depsQueue);
        // newProc4.SetDependents(depsQueue);
        applicationConfiguration.MaxParallelConsumeCount = _context.VehicleRootProcessor.TotalAmountOfProcessors;
        return _context;
    }
    
    public  TrafficProcessingContext  ConfigureDependentProcessorsCase2(ApplicationConfiguration applicationConfiguration,ILogger logger,IMapper mapper)
    {
        var _context = new TrafficProcessingContext(applicationConfiguration);
        
        var loggerService = new EventLoggingService(logger);

        _context.InitializeProcessors(applicationConfiguration, mapper, loggerService);
        
        //TypeDependant
        _context.VehicleRootProcessor.AddDependentProcessor(_context.VehicleMarkProcessor);
        _context.VehicleRootProcessor.AddDependentProcessor(_context.VehicleDangerProcessor);
        
        
        //MarkDependant                                  
        // _context.VehicleMarkProcessor.AddDependentProcessor(_context.VehicleColorProcessor);
        // _context.VehicleMarkProcessor.AddDependentProcessor(_context.VehicleSeasonProcessor);
        // _context.VehicleMarkProcessor.AddDependentProcessor(_context.VehicleTrafficProcessor);                                
        _context.VehicleDangerProcessor.AddDependentProcessor(_context.VehicleColorProcessor);
        _context.VehicleDangerProcessor.AddDependentProcessor(_context.VehicleSeasonProcessor);
        _context.VehicleDangerProcessor.AddDependentProcessor(_context.VehicleTrafficProcessor);
        
        var newProc = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateFirstProcessor", _context.GetLongRunningTask);
        var newProc2 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateSecondProcessor", _context.GetLongRunningTask);
        var newProc3 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateThirdProcessor", _context.GetLongRunningTask);
        
        var newProc4 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateFourProcessor", _context.GetLongRunningTask);
        var newProc5 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateFourProcessor", _context.GetLongRunningTask);
        var newProc6 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateFourProcessor", _context.GetLongRunningTask);
        var newProc7 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateFourProcessor", _context.GetLongRunningTask);
        var newProc8 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateFourProcessor", _context.GetLongRunningTask);
        var newProc9 = new TemplateProcessor<Track, PoolProcessionResult>(loggerService, "TemplateFourProcessor", _context.GetLongRunningTask);
        _context.VehicleSeasonProcessor.AddDependentProcessor(newProc);
        _context.VehicleSeasonProcessor.AddDependentProcessor(newProc2);
        _context.VehicleSeasonProcessor.AddDependentProcessor(newProc3);
        // newProc3.AddDependentProcessor(newProc7);
        // _context.VehicleTrafficProcessor.AddDependentProcessor(newProc);
        // _context.VehicleTrafficProcessor.AddDependentProcessor(newProc2);
        // _context.VehicleTrafficProcessor.AddDependentProcessor(newProc3);
        // _context.VehicleDangerProcessor.AddDependentProcessor(newProc2);
        // _context.VehicleDangerProcessor.AddDependentProcessor(newProc3);
        // _context.VehicleDangerProcessor.AddDependentProcessor(newProc4);
        string[] newNames = {"Volvo", "BMW", "Ford"};
        string[] newNames2 = {"Koko", "Mila", "Oni"};
        var deps = GetTemplateProcessorsWithNames(newNames, loggerService, _context);
        var dep2 = GetTemplateProcessorsWithNames(newNames2, loggerService, _context);
        var depsQueue = new ConcurrentQueue<IProgressiveProcessor<Track>>(deps);
        var depsQueue2 = new ConcurrentQueue<IProgressiveProcessor<Track>>(dep2);
        // newProc2.SetDependents(depsQueue);

        applicationConfiguration.MaxParallelConsumeCount = _context.VehicleRootProcessor.TotalAmountOfProcessors;
        return _context;
    }
    
    
    private List<TemplateProcessor<Track, PoolProcessionResult>> GetTemplateProcessorsWithNames(string[] names, EventLoggingService eventLoggingService, TrafficProcessingContext context)
    {
        return new List<TemplateProcessor<Track, PoolProcessionResult>>(names.Select(n =>
            new TemplateProcessor<Track, PoolProcessionResult>(eventLoggingService, n, context.GetLongRunningTask)));
    }
}