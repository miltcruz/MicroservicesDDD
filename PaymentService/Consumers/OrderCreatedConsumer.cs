using System;
using System.Threading.Tasks;
using MassTransit;
using SharedService.Domain.Events;
using SharedService.Infrastructure;
using SharedService.Domain.Entities;

namespace PaymentService.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderCreatedConsumer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var order = context.Message;
            Console.WriteLine($"Processing payment for Order {order.OrderId}, Amount: {order.Amount}");

            // Simulate Payment Processing
            await Task.Delay(1000);

            Console.WriteLine($"Payment successful for Order {order.OrderId}");
        }
    }
}