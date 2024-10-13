using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using ParallelProcessing.Configuration;
using ParallelProcessing.Consumers.Abstractions;
using ParallelProcessing.Contexts;
using ParallelProcessing.Models;
using ParallelProcessing.Processors.Abstractions;
using ParallelProcessing.Services.Events.Data.Enums;

namespace ParallelProcessing.Consumers;

public class TrackConsumer : ITrackConsumer
{
    public SortedSet<int> Treads { get; set; }
    private IProgressiveProcessor<Track> _rootProcessor;
    private TrafficProcessingContext _context;
    private ApplicationConfiguration _config;
    private Func<TrafficProcessingContext> ConfigureDependentProcessors;
    private  Stopwatch Stopwatch;

    public TrackConsumer(ApplicationConfiguration config,  TrafficProcessingContext context, Func<TrafficProcessingContext> configureDependentProcessors)
    {
        _config = config;
        _context = context;
        this.ConfigureDependentProcessors = configureDependentProcessors;
    }
    
    public async Task ConsumeAllAsync(ISourceBlock<Track> buffer, Func<ITargetBlock<Track>, Task> startProducing)
    {
        _context.VehicleRootProcessor.NestedProcessingCompletedEvent += RootProcessorOnNestedProcessingCompleted;
        var consumerBlock = new ActionBlock<Track>(
            track =>
            {
                var ctxt = GetFreshContext();

                //todo Wait for event before ProcessNext
                return ctxt.VehicleRootProcessor.ProcessNextAsync(track);
            },
            new ExecutionDataflowBlockOptions
            {
                BoundedCapacity = _config.BoundedCapacity,
                MaxDegreeOfParallelism = _config.MaxParallelConsumeCount
            });
        buffer.LinkTo(consumerBlock, new DataflowLinkOptions()
        { PropagateCompletion = _config.PropagateCompletion });

        await startProducing(consumerBlock);
        Stopwatch = System.Diagnostics.Stopwatch.StartNew();
        await consumerBlock.Completion;
        // watch.Stop();
        // var elapsedMs = watch.ElapsedMilliseconds;
        // var sec = TimeSpan.FromMilliseconds(elapsedMs).TotalSeconds;
        // Console.WriteLine($"!!!!!!!!!!!!!!!Total Time:{sec} SECONDS!!!!!!!!!!!!!!!!!");

    }
    

    private TrafficProcessingContext GetFreshContext()
    {
        
        return _context;
    }

    private  async Task RootProcessorOnNestedProcessingCompleted()
    {
        if (Stopwatch != null)
        {
            Stopwatch.Stop();
            var elapsedMs = Stopwatch.ElapsedMilliseconds;
            var sec = TimeSpan.FromMilliseconds(elapsedMs).TotalSeconds;
            await _context.EventLogger.Log(sec.ToString(), EventLoggingTypes.TotalProcessionTimeLogging);
            _context.VehicleRootProcessor.NestedProcessingCompletedEvent += RootProcessorOnNestedProcessingCompleted;
        }
    }
}