namespace Ecommerce.API.Product.Interfaces
{
    public interface IProductProvider
    {         
        Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)> GetProductAsync();
        Task<(bool IsSuccess, Models.Product Product, string ErrorMessage)> GetProductAsync(int id);
    }
}
