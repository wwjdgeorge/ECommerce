using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Product.DB
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
