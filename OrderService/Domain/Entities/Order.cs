namespace OrderService.Domain.Entities {
    public class Order {
        public Guid Id { get; set; }
        public string CustomerId { get; set; } = "";
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}