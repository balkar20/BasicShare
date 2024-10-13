using System.Threading.Tasks.Dataflow;
using ParallelProcessing.Models;

namespace ParallelProcessing.Consumers.Abstractions;

public interface IConsumer<TBufferData>
{
    // ITargetBlock<TBufferData> ConsumeAllAsync(BufferBlock<TBufferData> buffer);
    Task ConsumeAllAsync(ISourceBlock<Track> buffer,
        Func<ITargetBlock<Track>, Task> startProducing);
}