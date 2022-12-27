namespace Client
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using MassTransit;
    using Microsoft.Extensions.Hosting;

    public class StartupService :
            BackgroundService
    {
        readonly IBus _bus;
        readonly ILogger<StartupService> _log;
        readonly IRequestClient<Order> _getOrderStatus;

        public StartupService(IBus bus, ILogger<StartupService> log, IRequestClient<Order> getOrderStatus)
        {
            _bus = bus;
            _log = log;
            _getOrderStatus = getOrderStatus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           Thread.Sleep(3000);
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            _log.LogInformation("PUBLISHED ");
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            var response = await _getOrderStatus.GetResponse<Order>(new { Greeting = "Hello, World" });
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            _log.LogInformation($"{response.Message.Greeting}");
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            /*
            await _bus.Publish<Order>(new { Greeting = "Hello, World" }, stoppingToken);
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            _log.LogInformation("PUBLISHED");
            _log.LogInformation("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            */
        }
    }
}
