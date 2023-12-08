namespace ECommerce.API.Orders.Profiler
{
    public class OrderProfiler: AutoMapper.Profile
    {
        public OrderProfiler()
        {
            CreateMap<DB.OrderItem, Models.OrderItems>();
            CreateMap<DB.Order, Models.Order>();
        }
        
    }
}
