namespace SharedService.Domain.Entities {
    public class Order {
        public Guid Id { get; set; }
        public string CustomerId { get; set; } = "";
        public decimal Amount { get; set; }
        public bool IsPaymentSuccessful { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}