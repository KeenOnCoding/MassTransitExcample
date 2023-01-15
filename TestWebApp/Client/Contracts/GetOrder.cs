using Contracts;
using MassTransit.Mediator;

namespace Client.Handlers;

public record GetOrder() : Request<Order>
{
    public string Greeting { get; set; }
}
