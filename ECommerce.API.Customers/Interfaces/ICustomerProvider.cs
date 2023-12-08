using ECommerce.API.Customers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.API.Customers.Interfaces
{
    public interface ICustomerProvider
    { 
        Task<(bool isSuccess, IEnumerable<Models.Customer> customers, string ErrorMessage)> GetCustomerAsync();
        Task<(bool isSuccess, Models.Customer  customer, string ErrorMessage)> GetCustomerByIdAsync(int customerId);
    }
}
