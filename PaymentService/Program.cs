using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using PaymentService.Consumers;


// Load environment variables from .env
var rabbitMqHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitmq";
var rabbitMqUser = Environment.GetEnvironmentVariable("RABBITMQ_USER") ?? "guest";
var rabbitMqPass = Environment.GetEnvironmentVariable("RABBITMQ_PASS") ?? "guest";


var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => {
        services.AddMassTransit(x => {
            x.AddConsumer<OrderCreatedConsumer>();
            x.UsingRabbitMq((ctx, cfg) => {
                cfg.Host(rabbitMqHost, h => {
                    h.Username(rabbitMqUser);
                    h.Password(rabbitMqPass);
                });
                cfg.ReceiveEndpoint("order-created-queue", ep => {
                    ep.ConfigureConsumer<OrderCreatedConsumer>(ctx);
                });
            });
        });
    })
    .Build();

await builder.RunAsync();