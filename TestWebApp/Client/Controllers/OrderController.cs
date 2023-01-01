﻿using Client.Handlers;
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
        readonly ILogger<OrderController> _logger;
        readonly IRequestClient<Order> _getOrderStatus;
       readonly IBus _publishEndpoint;
        readonly IMediator _mediator;
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

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.SendRequest(new GetOrder { });
            return Ok(result.Greeting);

            /*
            var response = await _getOrderStatus.GetResponse<Order>(new { Greeting = "Hello, World" });
            return Ok(new { response.Message.Greeting });
            */

        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
