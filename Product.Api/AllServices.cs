
using Writer.Api.Repository;
using Writer.Api.Repository.Interface;

namespace Article.Api
{
    public static class AllServices
    {
        public static void registers(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
