namespace Server
{
    using System.Threading.Tasks;
    using Contracts;
    using MassTransit;

    public class ClientAvailableConsumer :
        IConsumer<Order>
    {
        readonly ILogger<ClientAvailableConsumer> _log;

        public ClientAvailableConsumer(ILogger<ClientAvailableConsumer> log)
        {
            _log = log;
        }

        public async Task Consume(ConsumeContext<Order> context)
        {
            if (context.IsResponseAccepted<Order>())
                await context.RespondAsync<Order>(new { Greeting = "Hello, from consumer" });
        }

        //    public class ClientAvailableConsumerDefinition :
        //ConsumerDefinition<ClientAvailableConsumer>
        //    {
        //        public ClientAvailableConsumerDefinition()
        //        {
        //            EndpointName = "direct.server";
        //        }
        //    }
    }
}
