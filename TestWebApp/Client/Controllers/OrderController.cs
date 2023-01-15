using Contracts;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IRequestClient<Order> _getOrderStatus;
        private readonly IBus _publishEndpoint;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger,
            IRequestClient<Order> getOrderStatus,
            IBus publishEndpoint,
            IMediator mediator)
        {
            _logger = logger;
            _getOrderStatus = getOrderStatus;
            _publishEndpoint = publishEndpoint;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var result = await _mediator.SendRequest(new GetOrder {Greeting = "Hello, from " }) ?? throw new  ArgumentNullException();
            //return Ok(result.Greeting);

            await _publishEndpoint.Publish<Order>(new { Greeting = "HELLO, WORLD!" });
            return Ok();
        }
    }
}