using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(Guid orderId);
        Task<Order[]> GetOrdersAsync();
    }
}