using AutoMapper;
using ECommerce.API.Customers.DB;
using ECommerce.API.Customers.Interfaces;
using ECommerce.API.Customers.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;

namespace ECommerce.API.Customers.Providers
{
    public class CustomerProvider : ICustomerProvider
    {
        private readonly ILogger<CustomerProvider> _logger;
        private readonly IMapper _mapper;
        private readonly CustomersDBContext _dBContext;

        public CustomerProvider(ILogger<CustomerProvider> logger, IMapper mapper, CustomersDBContext dBContext) {
            _logger = logger;
            _mapper = mapper;
            _dBContext = dBContext;
            SeedData();
        }

        private void SeedData()
        {
            
            if (!_dBContext.Customers.Any())
            {
                _dBContext.Customers.Add(new DB.Customer() { Id = 1, Name = "George", Address = "123" });
                _dBContext.Customers.Add(new DB.Customer() { Id = 2, Name = " M1", Address = "1234" });
                _dBContext.Customers.Add(new DB.Customer() { Id = 3, Name = " M2", Address = "12345" });
                _dBContext.SaveChanges();

                //var cust = new List<Customer>()
                //{
                //    new DB.Customer{Id=1, Name ="George", Address ="123"},
                //}

            }

        }

        public async Task<(bool isSuccess, IEnumerable<Models.Customer> customers, string ErrorMessage)> GetCustomerAsync()
        {
            try
            {
                var customers = await _dBContext.Customers.ToListAsync();
                if (customers.Any() && customers != null)
                {
                    var result = _mapper.Map<IEnumerable<DB.Customer>, IEnumerable<Models.Customer>>(customers);
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

        public async Task<(bool isSuccess, Models.Customer customer, string ErrorMessage)> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var customer = await _dBContext.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
                if (customer != null)
                {
                    var result = _mapper.Map<DB.Customer, Models.Customer>(customer);
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
