using Contracts;
using MassTransit;
using MassTransit.Mediator;
using System.Text.Json;

namespace Client.Handlers;

public class InventoryConsumer :
    MediatorRequestHandler<GetOrder, Order>
{
    readonly IRequestClient<Order> _getOrderStatus;
    public InventoryConsumer(IRequestClient<Order> getOrderStatus)
    {
        _getOrderStatus = getOrderStatus;
    }
    protected override async Task<Order> Handle(GetOrder request, CancellationToken cancellationToken)
    {
        var response = await _getOrderStatus.GetResponse<Order>(new { Greeting = "" });
        var result = await Task.FromResult(new Order { Greeting = response.Message.Greeting });
        return result;
       /*
        return Task.FromResult(new InventoryStatus
        {
            Sku = request.Sku,
            OnHand = Random.Shared.Next(1, 1000)
        });
        */
    }
}