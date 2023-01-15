using Contracts;
using MassTransit;
using MassTransit.Mediator;

namespace Client.Handlers;

public class OrderHandler :
    MediatorRequestHandler<GetOrder, Order>
{
    readonly IRequestClient<Order> _getOrderStatus;
    public OrderHandler(IRequestClient<Order> getOrderStatus)
    {
        _getOrderStatus = getOrderStatus;
    }
    protected override async Task<Order> Handle(GetOrder request, CancellationToken cancellationToken)
    {
        var response = await _getOrderStatus.GetResponse<Order>(new { request.Greeting });

        return await Task.FromResult(new Order() { Greeting =  response.Message.Greeting });
    }
}