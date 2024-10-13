using System.Collections.Concurrent;

namespace ParallelProcessing.Processors.Abstractions;

public interface IProgressiveProcessor<TInput>
{
    //Properties
    bool IsCompletedNestedProcessing { get;  }
    bool IsCompletedSelfProcessing { get; set; }
    bool IsStartedSelfProcessing { get; set; }
    bool IsRoot { get; set; }
    bool IsDependantRoot { get; set; }
    int TotalAmountOfProcessors {get; set; }
    int InitialAmountOfNotExecutedDependantProcessors {get; set; }
    
    bool IsSomeOfNestedRootsProcessingCompletedEventFired {get; set; }
    
    
    
    ConcurrentStack<IProgressiveProcessor<TInput>> ProcessorsExecuting { get; set; }
    string ProcessorTypeName { get; set; }
    string ProcessorName { get; set; }
    int DependentProcessorsExecutingCount { get; set; }
    IProgressiveProcessor<TInput>? ParentProcessor { get; set; }
    IProgressiveProcessor<TInput>? RootProcessorFromDependentQueue { get; set; }
    ConcurrentQueue<IProgressiveProcessor<TInput>> DependedProcessors { get; set; }
    ConcurrentQueue<IProgressiveProcessor<TInput>>? RootsFromDependantQueuePool { get; }
    bool GotDependentProcessorsExecutingCountFromDependentRoot { get; set; }

    Task ProcessNextAsync(TInput inputData);
    Task DoConditionalProcession(TInput inputData);
    void AddDependentProcessor(IProgressiveProcessor<TInput> dependentProcessor);
    void SetDependents(ConcurrentQueue<IProgressiveProcessor<TInput>> dependents);
    int IncrementParentsTotalCount(int count, IProgressiveProcessor<TInput> parentProcessor);
    int DecrementParentsTotalCount(int count, IProgressiveProcessor<TInput> parentProcessor);
    void RecursivelySetRootProcessorForDependentQueueToParent(IProgressiveProcessor<TInput> processor, IProgressiveProcessor<TInput> parentProcessor);
    void RecursivelySetRootProcessorForDependentQueuePoolToParent(IProgressiveProcessor<TInput> processor, IProgressiveProcessor<TInput> parentProcessor);
    Task SignalNestedProcessingCompletionEvent();
    Task SignalDependantProcessorWasDequeuedEvent();
    Task SignalSomeOfNestedRootsProcessingCompletedEvent();
    
    //Events
    event Func<Task> NestedProcessingCompletedEvent;
    event Func<Task> SomeOfNestedRootsProcessingCompletedEvent;
    event Func<Task> DependantProcessorWasDequeuedEvent;
    event Func<Task> CurrentProcessingCompletedEvent;
    event Func<TInput, Task> ParentProcessingCompletedEvent;
}