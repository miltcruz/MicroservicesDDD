using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using PaymentService.Consumers;
using SharedService.Infrastructure;


// Load environment variables from .env
var rabbitMqHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitmq";
var rabbitMqUser = Environment.GetEnvironmentVariable("RABBITMQ_USER") ?? "guest";
var rabbitMqPass = Environment.GetEnvironmentVariable("RABBITMQ_PASS") ?? "guest";

var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "postgres"; // Use the service name defined in docker-compose.yml
var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB");
var username = Environment.GetEnvironmentVariable("POSTGRES_USER");
var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

var connectionString = $"Host={host};Database={dbName};Username={username};Password={password}";

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) => {
        services.AddApplicationDbContext(connectionString);
        services.AddCustomServices();
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