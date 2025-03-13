using Microsoft.EntityFrameworkCore;
using SharedService.Domain.Entities;

namespace SharedService.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSets for your entities
        public DbSet<Order> Orders { get; set; }
    }
}