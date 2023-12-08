using AutoMapper;
using Ecommerce.API.Product.Controllers;
using Ecommerce.API.Product.DB;
using Ecommerce.API.Product.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Ecommerce.API.Product.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly ILogger<ProductProvider> _logger;
        private readonly ProductDbContext _productDbContext;
        private readonly IMapper _mapper;

        public ProductProvider(ILogger<ProductProvider>  logger, ProductDbContext productDbContext, IMapper mapper) {
            _logger = logger;
            _productDbContext = productDbContext;
            _mapper = mapper;
            seedData();
        }
        private void seedData()
        {
           if( !_productDbContext.Products.Any())
            {
                _productDbContext.Products.Add(new DB.Product() { Id = 1, Name = "k", Inventory = 1, Price = 12 });
                _productDbContext.Products.Add(new DB.Product() { Id = 2, Name = "mouse", Inventory = 1, Price = 14 });
                _productDbContext.Products.Add(new DB.Product() { Id = 3, Name = "Moni", Inventory = 1, Price = 15 });
                _productDbContext.Products.Add(new DB.Product() { Id = 4, Name = "CPU", Inventory = 1, Price = 17 });
                _productDbContext.Products.Add(new DB.Product() { Id = 5, Name = "f", Inventory = 1, Price = 182 });
                _productDbContext.SaveChanges();
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)> GetProductAsync()
        {
            try
            {
                var products = await _productDbContext.Products.ToListAsync();
                if (products != null && products.Any())
                {

                    var result = _mapper.Map<IEnumerable<DB.Product>, IEnumerable<Models.Product>>(products);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                  return (false, null, ex.ToString());
            }

        }

        public async Task<(bool IsSuccess, Models.Product Product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                var product = await _productDbContext.Products.FirstOrDefaultAsync(i=> i.Id == id);
                if (product != null)
                {

                    var result = _mapper.Map<DB.Product, Models.Product>(product);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.ToString());
            }

        }
    }
}
