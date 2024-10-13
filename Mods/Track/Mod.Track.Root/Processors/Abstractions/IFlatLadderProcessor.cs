using System.Collections.Concurrent;

namespace ParallelProcessing.Processors.Abstractions;

public interface IFlatLadderProcessor<TInput>
{
    //Properties
    public bool IsCompletedNestedProcessing { get; set; }
    public bool IsCompletedCurrentProcessing { get; set; }
    public bool IsStartedSelfProcessing { get; set; }
    bool IsRoot { get; set; }
    int TotalAmountOfProcessors {get; set; }
    
    
    ConcurrentStack<IFlatLadderProcessor<TInput>> ProcessorsExecuting { get; set; }
    string ProcessorTypeName { get; set; }
    string ProcessorName { get; set; }
    int DependentProcessorsExecutingCount { get; set; }
    IFlatLadderProcessor<TInput>? ParentProcessor { get; set; }
    IFlatLadderProcessor<TInput>? RootProcessorFromDependentQueue { get; set; }
    ConcurrentQueue<IFlatLadderProcessor<TInput>> DependedProcessors { get; set; }
    bool GotDependentProcessorsExecutingCountFromDependentRoot { get; set; }

    Task ProcessNextAsync(TInput inputData);
    Task DoConditionalProcession(TInput inputData);
    void AddDependentProcessor(IFlatLadderProcessor<TInput> dependentProcessor);
    void SetDependents(ConcurrentQueue<IFlatLadderProcessor<TInput>> dependents);
    int IncrementParentsTotalCount(int count, IFlatLadderProcessor<TInput> parentProcessor);
    int DecrementParentsTotalCount(int count, IFlatLadderProcessor<TInput> parentProcessor);
    void RecursivelySetParent(IFlatLadderProcessor<TInput> processor, IFlatLadderProcessor<TInput> parentProcessor);
    Task SignalNestedProcessingCompletion();
    
    //Events
    event Func<Task> NestedProcessingCompletedEvent;
    event Func<IFlatLadderProcessor<TInput>, int, Task> CurrentProcessingCompletedEvent;
    event Func<TInput, Task> ParentProcessingCompletedEvent;
}