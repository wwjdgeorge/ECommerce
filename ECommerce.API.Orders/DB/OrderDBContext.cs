using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Orders.DB
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders
        {
            get; set;
        }
    }
}
