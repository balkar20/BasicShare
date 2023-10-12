namespace Contracts
{
    using System;

    public record OrderOrchestratorEvent
    {
        public Guid CorrelationId { get; init; }
        public string Value { get; init; }
    }
}