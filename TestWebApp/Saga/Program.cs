using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saga.StateMachines;
using System.Reflection;

var host = Host.CreateDefaultBuilder(args)
    .UseMassTransit((x, y) =>
    {
        y.SetKebabCaseEndpointNameFormatter();
        
        var entryAssembly = Assembly.GetAssembly(typeof(Program));

        y.AddConsumers(entryAssembly);
        
        y.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("rabbitmq", "/");
            cfg.ConfigureEndpoints(context);
        });
        
        y.AddSagaStateMachine<OrderStateMachine, OrderState, OrderStateDefinition>()
            .InMemoryRepository();
        //y.AddOptions<MassTransitHostOptions>()
        //        .Configure(options =>
        //        {
        //            options.WaitUntilStarted = true;
        //        });
    })
    .Build();

await host.RunAsync();