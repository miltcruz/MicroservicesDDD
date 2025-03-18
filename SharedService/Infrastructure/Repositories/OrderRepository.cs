using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedService.Domain.Entities;

namespace SharedService.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order[]> GetOrdersAsync() => await _context.Orders.ToArrayAsync();

        public async Task<Order?> GetOrderByIdAsync(Guid orderId) => await _context.Orders.FindAsync(orderId);

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}