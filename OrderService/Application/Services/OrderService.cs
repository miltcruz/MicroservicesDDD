using MassTransit;
using OrderService.Domain.Entities;
using SharedService.Events;
using OrderService.Infrastructure.Repositories;

namespace OrderService.Application.Services
{
    public class OrderSrv
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderSrv(IOrderRepository orderRepository, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task CreateOrderAsync(string customerId, decimal amount)
        {
            var order = new Order { Id = Guid.NewGuid(), CustomerId = customerId, Amount = amount };
            await _orderRepository.AddOrderAsync(order);
            await _publishEndpoint.Publish(new OrderCreatedEvent(order.Id, order.Amount, order.CustomerId));
        }
    }
}