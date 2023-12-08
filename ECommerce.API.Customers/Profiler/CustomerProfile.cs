namespace ECommerce.API.Customers.Profiler
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<DB.Customer,Models.Customer>();
        }        
    }
}
