using SharedService.Domain.Entities;

namespace SharedService.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(Guid orderId);
        Task<Order[]> GetOrdersAsync();

        Task UpdateOrderAsync(Order order);
    }
}