namespace Server
{
    using System.Threading.Tasks;
    using Contracts;
    using MassTransit;
    using MassTransit.Definition;

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
            Thread.Sleep(3000);
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            _log.LogInformation($"{context.Message.Greeting}");
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            //if (context.IsResponseAccepted<Order>())
                await context.RespondAsync<Order>(new { Greeting = "Hello, from consumer" });
        }


        /*
        public async Task Consume(ConsumeContext<Order> context)
        {
            Thread.Sleep(3000);
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            _log.LogInformation($"{context.Message.Greeting}");
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            await Task.CompletedTask;
        }
        */



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
