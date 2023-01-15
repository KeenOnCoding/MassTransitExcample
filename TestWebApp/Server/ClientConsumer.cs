namespace Server
{
    using System.Threading.Tasks;
    using Contracts;
    using MassTransit;
    using Microsoft.Extensions.Logging;

    public class ClientConsumer :
        IConsumer<Order>
    {
        readonly ILogger<ClientConsumer> _log;

        public ClientConsumer(ILogger<ClientConsumer> log) => _log = log;


        public async Task Consume(ConsumeContext<Order> context)
        {
            
            _log.LogInformation($"DIRECT CONTENT RECEIVED: {context.Message.Greeting}");
            await Task.CompletedTask;

            /*
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine("ClientAvailableConsumer ");
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - ");
            if (context.IsResponseAccepted<Order>())
                await context.RespondAsync<Order>(new { Greeting = context.Message.Greeting + "ClientAvailableConsumer" });
        */
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
