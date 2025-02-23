

using Product.Infrastructure.Repositories;
using Product.Infrastructure.Repositories.Interfaces;


namespace Order.Api
{
    public static class AllServices
    {
        public static void registers(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
