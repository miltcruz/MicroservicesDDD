using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using PaymentService.Consumers;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => {
        services.AddMassTransit(x => {
            x.AddConsumer<OrderCreatedConsumer>();
            x.UsingRabbitMq((ctx, cfg) => {
                cfg.Host("rabbitmq://localhost");
                cfg.ReceiveEndpoint("order-created-queue", ep => {
                    ep.ConfigureConsumer<OrderCreatedConsumer>(ctx);
                });
            });
        });
    })
    .Build();

await builder.RunAsync();