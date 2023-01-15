namespace Saga.StateMachines;

using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

#pragma warning disable CS8618
public class OrderStateMachine : MassTransitStateMachine<OrderState>
{
    public OrderStateMachine(ILogger<OrderStateMachine> logger)
    {
        InstanceState(x => x.CurrentState);

        Event(() => Order, _ => {
            _.CorrelateById(context => context.Message.Id);
            logger.LogInformation("EVENT"); 
        }) ;

        Initially(
            When(Order)
            .TransitionTo(Submitted)
            .Then(_ => logger.LogInformation("EVENT TRIGGERED")));
    }

    public Event<Order> Order { get; }
    public State Submitted { get; private set; }

}