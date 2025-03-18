using System;
using System.Threading.Tasks;
using MassTransit;
using SharedService.Domain.Events;
using SharedService.Application.Services;
using SharedService.Domain.Entities;

namespace PaymentService.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly OrderSrv _orderService;

        public OrderCreatedConsumer(OrderSrv orderService)
        {
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var order = context.Message;
            Console.WriteLine($"Processing payment for Order {order.OrderId}, Amount: {order.Amount}");

            // Simulate Payment Processing
            await Task.Delay(1000);

            await _orderService.UpdateOrderAsync(new Order { 
                Id = order.OrderId, 
                CustomerId = order.CustomerId, 
                Amount = order.Amount, 
                IsPaymentSuccessful = true,
                UpdatedAt = DateTime.UtcNow
            });

            Console.WriteLine($"Payment successful for Order {order}");
        }
    }
}