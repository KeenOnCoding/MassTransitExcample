namespace Saga.StateMachines;
using MassTransit;

public class OrderState : SagaStateMachineInstance
{
    public string? CurrentState { get; set; }
    public Guid CorrelationId { get; set; }
}