using Client;
using Client.Handlers;
using Contracts;
using MassTransit;
using System.Reflection;
using static MassTransit.Monitoring.Performance.BuiltInCounters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.AddRequestClient<Order>();

    var entryAssembly = Assembly.GetAssembly(typeof(Program));

    x.AddConsumers(entryAssembly);

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/");
        cfg.ConfigureEndpoints(context);
    });
});
builder.Services.AddMediator(x => x.AddConsumersFromNamespaceContaining<Handlers>());

//builder.Services.AddHostedService<StartupService>();

//builder.Services.AddMassTransitHostedService(true);
builder.Services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    options.WaitUntilStarted = true;
                });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
