using System.Threading.Tasks.Dataflow;
using ParallelProcessing.Models;

namespace ParallelProcessing.Producers.Abstraction;

public interface IProducer
{
    Task ProduceAllAsync(ITargetBlock<Track> target);
}