using System;
using System.Threading.Tasks;
using MassTransit;
using SharedService.Events;

namespace PaymentService.Consumers {
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent> {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context) {
            var order = context.Message;
            Console.WriteLine($"Processing payment for Order {order.OrderId}, Amount: {order.Amount}");
            
            // Simulate Payment Processing
            await Task.Delay(1000);
            
            Console.WriteLine($"Payment successful for Order {order.OrderId}");
        }
    }
}