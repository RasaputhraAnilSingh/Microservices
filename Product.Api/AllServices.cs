

using Product.Infrastructure.MongoDB;
using Product.Infrastructure.Repositories;
using Product.Infrastructure.Repositories.Interfaces;
using System.Configuration;


namespace Order.Api
{
    public static class AllServices
    {
        public static void registers(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddSingleton<MongoDbService>();
        }
    }
}
