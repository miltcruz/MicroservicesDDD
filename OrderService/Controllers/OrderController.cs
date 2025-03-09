using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Services;
using OrderService.Domain.Entities;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderSrv _orderService;

        public OrderController(OrderSrv orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            var order = await _orderService.CreateOrderAsync(request.CustomerId, request.Amount);
            return Ok(new { orderId = order.Id });
        }

        [HttpGet("read")]
        public async Task<IActionResult> GetOrders()
        {
            Order[] orders = await _orderService.GetOrdersAsync();
            return Ok(new { orders });
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var order = await _orderService.GetOrderAsync(orderId);
            if (order == null)
                return NotFound(new { message = "Order not found" });

            return Ok(order);
        }
    }

    public record OrderRequest(string CustomerId, decimal Amount);
}