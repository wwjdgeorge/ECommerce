using AutoMapper;

namespace Ecommerce.API.Product.Profiler
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<DB.Product, Models.Product>();
        }
    }
}
