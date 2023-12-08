using Ecommerce.API.Product.DB;
using Microsoft.EntityFrameworkCore;

 
using Ecommerce.API.Product.Profiler;
using Ecommerce.API.Product.Providers;
using AutoMapper;
using Ecommerce.API.Product.Interfaces;

namespace ECommerce.API.Product.Tests
{
    public class ProductsServiceTest
    {
        [Fact]
        public async Task GetProductsReturnsAllProducts()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                            .UseInMemoryDatabase(nameof(GetProductsReturnsAllProducts))
                            .Options;
            var dbContext = new ProductDbContext(options);
            CreateProducts(dbContext);
            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);
            var productsProvider = new ProductProvider(null, dbContext, mapper);
            var product = await productsProvider.GetProductAsync();
            Assert.True(product.Products.Any());
            Assert.True(product.IsSuccess);
            Assert.Null(product.ErrorMessage);


        }
        private void CreateProducts(ProductDbContext dbContext)
        {
            for (int i = 1; i <= 10; i++)
            {
                dbContext.Products.Add(new Ecommerce.API.Product.DB.Product()
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString(),
                    Inventory = i + 10,
                    Price = (decimal)(i * 3.14)
                });
            }
            dbContext.SaveChanges();
        }
    }
}