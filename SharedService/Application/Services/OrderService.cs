using MassTransit;
using SharedService.Domain.Entities;
using SharedService.Domain.Events;
using SharedService.Infrastructure.Repositories;

namespace SharedService.Application.Services
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

        public async Task<Order> CreateOrderAsync(string customerId, decimal amount)
        {
            var order = new Order { Id = Guid.NewGuid(), CustomerId = customerId, Amount = amount };
            await _orderRepository.AddOrderAsync(order);
            await _publishEndpoint.Publish(new OrderCreatedEvent(order.Id, order.Amount, order.CustomerId));
            return order;
        }

        public async Task<Order[]> GetOrdersAsync() => await _orderRepository.GetOrdersAsync();

        public async Task<Order?> GetOrderAsync(Guid orderId) => await _orderRepository.GetOrderByIdAsync(orderId);
    }
}