using System.Threading.Tasks.Dataflow;
using ParallelProcessing.ClientDevices.Abstractions;
using ParallelProcessing.Configuration;
using ParallelProcessing.Consumers.Abstractions;
using ParallelProcessing.Models;
using ParallelProcessing.Producers.Abstraction;

namespace ParallelProcessing.Root;

public class TrafficFlowProcessStarter(
    ITrackDevice trackDevice,
    ITrackProducer trackProducer,
    ITrackConsumer trackConsumer, 
    ApplicationConfiguration configuration)
{
    protected TimeSpan consumeSpeed => configuration.ConsumeSpeed;
    private  int maxParallelConsume => configuration.MaxParallelConsumeCount;

    // [Benchmark]
    public async Task StartProcess()
    {
        var buffer = new BufferBlock<Track>(
            new DataflowBlockOptions() { BoundedCapacity = maxParallelConsume });
        
        await trackConsumer.ConsumeAllAsync(buffer, block => 
            trackProducer.ProduceAllAsync(block));
    }
}