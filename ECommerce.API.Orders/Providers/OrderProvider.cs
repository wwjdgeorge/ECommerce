using AutoMapper;
using ECommerce.API.Orders.DB;
using ECommerce.API.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Orders.Providers
{
    public class OrderProvider : IOrderProvider
    {
        private readonly IMapper _mapper;
        private readonly ILogger<OrderProvider> _logger;

        private readonly OrderDBContext _orderDBContext;

        public OrderProvider(ILogger<OrderProvider> logger, OrderDBContext orderDBContext, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _orderDBContext = orderDBContext;
            SeedData();
        }
        private void SeedData()
        {
            if(!_orderDBContext.Orders.Any())
            {
                _orderDBContext.Orders.Add(new Order()
                {
                    Id=10,
                    CustomerId=10,
                    OrderDate = DateTime.Now,
                    Items = new List<OrderItem>()
                    {
                        new OrderItem() { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10 },
                        new OrderItem() {OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10},
                        new OrderItem() { OrderId = 1, ProductId = 3, Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 100 }
                    },
                    Total=100
                });
                _orderDBContext.Orders.Add(new DB.Order()
                {
                    Id = 2,
                    CustomerId = 1,
                    OrderDate = DateTime.Now.AddDays(-1),
                    Items= new List<OrderItem>()
                    {
                        new OrderItem() { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = 1, ProductId = 2, Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = 1, ProductId = 3, Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                _orderDBContext.Orders.Add(new Order()
                {
                    Id = 3,
                    CustomerId = 2,
                    OrderDate = DateTime.Now,
                    Items = new List<OrderItem>()
                    {
                        new OrderItem() { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                _orderDBContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Order> orders, string ErrorMessage)> GetOrdersAsync(int CustomerId)
        {
            try
            {
                var order = await _orderDBContext.Orders.Where(o => o.CustomerId == CustomerId)
                    .Include(o => o.Items)
                    .ToListAsync();

                if (order.Any())
                {
                    _mapper.Map<IEnumerable<DB.Order>, IEnumerable<Models.Order>>(order);
                    return (true, order, null);
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
