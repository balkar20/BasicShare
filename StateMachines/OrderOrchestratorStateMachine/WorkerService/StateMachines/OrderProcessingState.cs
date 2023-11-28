namespace Company.StateMachines
{
    using System;
    using MassTransit;

    public class OrderProcessingState :
        SagaStateMachineInstance 
    {
        public int CurrentState { get; set; }

        public string Value { get; set; }

        public Guid CorrelationId { get; set; }
    }
}