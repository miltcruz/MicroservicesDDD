using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using OrderService.Infrastructure;
using OrderService.Infrastructure.Repositories;
using OrderService.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseInMemoryDatabase("OrdersDb"));

builder.Services.AddMassTransit(x => {
    x.UsingRabbitMq((context, cfg) => cfg.Host("rabbitmq://localhost"));
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<Orders>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();