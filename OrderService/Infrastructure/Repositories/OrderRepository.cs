using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;

namespace OrderService.Infrastructure.Repositories {
    public class OrderRepository : IOrderRepository {
        private readonly ApplicationDbContext _context;
        
        public OrderRepository(ApplicationDbContext context) {
            _context = context;
        }
        
        public async Task AddOrderAsync(Order order) {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        
        public async Task<Order?> GetOrderByIdAsync(Guid orderId) => await _context.Orders.FindAsync(orderId);
    }
}