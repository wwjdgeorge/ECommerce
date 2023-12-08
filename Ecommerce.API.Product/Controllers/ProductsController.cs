using Ecommerce.API.Product.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Product.Controllers
{
    
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductProvider _productProvider;

        public ProductsController(IProductProvider productProvider) 
        {
            _productProvider = productProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductAsync()
        {
           var result =  await _productProvider.GetProductAsync();
            if(result.IsSuccess) {
                return Ok(result.Products);
            }
            return NotFound();
        }
         
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await _productProvider.GetProductAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }
            return NotFound();
        }
    }
}
