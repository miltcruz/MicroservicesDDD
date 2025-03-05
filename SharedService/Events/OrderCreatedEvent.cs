namespace SharedService.Events;

public record OrderCreatedEvent(Guid OrderId, decimal Amount, string CustomerId);