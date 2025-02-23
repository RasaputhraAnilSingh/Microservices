using Article.Api.Repository;
using Article.Api.Repository.Interface;

namespace Article.Api
{
    public static class AllServices
    {
        public static void registers(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
        }
    }
}
