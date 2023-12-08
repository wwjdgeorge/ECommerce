using ECommerce.API.Orders.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Orders.Controllers
{
     
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProvider _orderProvider;

        public OrderController(IOrderProvider orderProvider)
        {
            _orderProvider = orderProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAsync(int CustomerId)
        {
            var result = await _orderProvider.GetOrdersAsync(CustomerId);
            if (result.IsSuccess)
            {
                return Ok(result.orders);
            }
            return NotFound();
        }
    }
}
