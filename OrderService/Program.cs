using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

var builder = WebApplication.CreateBuilder(args);

// Use the methods from ServiceCollectionExtensions to add services
builder.Services.AddApplicationDbContext(connectionString);
builder.Services.AddCustomCors();
builder.Services.AddCustomMassTransit(rabbitMqHost, rabbitMqUser, rabbitMqPass);
builder.Services.AddCustomServices();
builder.Services.AddControllers();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80);
});

var app = builder.Build();

// Apply migrations at startup
app.Services.ApplyMigrations();

app.UseCors("AllowAll");
app.MapControllers();
app.Run();