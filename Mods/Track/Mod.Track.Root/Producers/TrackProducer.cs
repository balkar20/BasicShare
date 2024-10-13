using System.Threading.Tasks.Dataflow;
using ParallelProcessing.ClientDevices.Abstractions;
using ParallelProcessing.Configuration;
using ParallelProcessing.Models;
using ParallelProcessing.Producers.Abstraction;

namespace ParallelProcessing.Producers;

public class TrackProducer: ITrackProducer
{
    private readonly ITrackDevice _trackDevice;
    private readonly ApplicationConfiguration config;

    public TrackProducer(ITrackDevice trackDevice, ApplicationConfiguration config)
    {
        _trackDevice = trackDevice;
        this.config = config;
        Treads = new SortedSet<int>();
    }

    public SortedSet<int> Treads { get; set; }
    public async Task ProduceAllAsync(ITargetBlock<Track> target)
    {
        var sourceData = await _trackDevice.GiveMeTrackDataBunch("SomeTracks", config.MaxParallelConsumeCount);
        foreach (var track in sourceData.Tracks)
        {
            await ProduceOne(target, track);
            
            Treads.Add(Thread.CurrentThread.ManagedThreadId);
        }

        target.Complete();
    }

    private async Task ProduceOne(ITargetBlock<Track> target, Track track)
    {
        await Task.Delay(config.ProduceSpeed);
        await target.SendAsync(track);
    }
}