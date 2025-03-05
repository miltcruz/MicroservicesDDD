using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Services;

namespace OrderService.Controllers {
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase {
        private readonly Orders _orderService;
        
        public OrderController(Orders orderService) {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request) {
            await _orderService.CreateOrderAsync(request.CustomerId, request.Amount);
            return Ok(new { message = "Order created successfully." });
        }
    }

    public record OrderRequest(string CustomerId, decimal Amount);
}