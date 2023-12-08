using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Customers.DB
{
    public class CustomersDBContext : DbContext
    {
        public CustomersDBContext(DbContextOptions options): base(options) { 
        }
         public DbSet<Customer> Customers { get; set; }
    }
}
