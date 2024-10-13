using System.Collections.Concurrent;
using ParallelProcessing.Configuration;
using ParallelProcessing.Contexts;
using ParallelProcessing.Processors.Abstractions;

namespace ParallelProcessing.Processors.ProcessorOrchestration;

public class ObjectPool<T>
{
    private readonly ConcurrentBag<T> _objects;
    private readonly Func<T> _objectGenerator;

    public ObjectPool(Func<T> objectGenerator)
    {
        _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
        _objects = new ConcurrentBag<T>();
    }

    public T Get() => _objects.TryTake(out T item) ? item : _objectGenerator();

    public void Return(T item) => _objects.Add(item);
}

public class ProcessorPool<Track>
{
    private ApplicationConfiguration ApplicationConfiguration;
    public ProcessorPool(ApplicationConfiguration applicationConfiguration)
    {
        ApplicationConfiguration = applicationConfiguration;
    }
    private IProgressiveProcessor<Track> ReadyRootProcessor;
    private ObjectPool<TrafficProcessingContext> Pool;
    private TrafficProcessingContext _currentProcessingContext;
    private Action _reconstruct;
    private Func<TrafficProcessingContext> _reconstructTrafficProcessingContext;
    
    public void Foo()
    {
        ReadyRootProcessor.NestedProcessingCompletedEvent +=  ReadyRootProcessorOnNestedProcessingCompleted;
    }

    private async Task ReadyRootProcessorOnNestedProcessingCompleted()
    {
        //1st step - to replace ReadyRootProcessor - get him from pool
        var oldProcessor = _currentProcessingContext;
        _currentProcessingContext = Pool.Get();
        
        //2st step - to reconstruct oldProcessor and return him to the pool
        // Reconstruct();
        Pool.Return(_reconstructTrafficProcessingContext());
    }

    // private void Reconstruct()
    // {
    //     // // reconstructAction();
    //     // _reconstruct();
    //     _currentProcessingContext = _reconstructTrafficProcessingContext();
    // }
}