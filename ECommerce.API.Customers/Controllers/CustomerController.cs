using ECommerce.API.Customers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Customers.Controllers
{
    [ApiController]
    [Route("api/Customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerProvider _customerProvider;

        public CustomerController(ICustomerProvider customerProvider)
        {
            _customerProvider = customerProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerAsync()
        {
            var result = await _customerProvider.GetCustomerAsync();
            if (result.isSuccess)
            {
                return Ok(result.customers);
            }
            return NotFound();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomerIdAsync(int id)
        {
            var result = await _customerProvider.GetCustomerByIdAsync(id);
            if (result.isSuccess)
            {
                return Ok(result.customer);
            }
            return NotFound();
        }
    }
}
