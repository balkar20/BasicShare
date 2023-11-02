namespace Contracts
{
    using System;

    public record OrderProcessingEvent
    {
        public Guid CorrelationId { get; init; }
        public string Value { get; init; }
    }
}