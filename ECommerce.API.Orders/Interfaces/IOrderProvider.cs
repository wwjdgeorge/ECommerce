using ECommerce.API.Orders.DB;

namespace ECommerce.API.Orders.Interfaces
{
    public interface IOrderProvider
    {
        Task<(bool IsSuccess, IEnumerable<Order> orders, string ErrorMessage)> GetOrdersAsync(int CustomerId);
    }
}
