namespace Core.Base.Output;

public record OutputViewModelWithData<TData>(bool IsOk, string? ErrorMessage, TData Data) : BaseOutputViewModel(IsOk, ErrorMessage);