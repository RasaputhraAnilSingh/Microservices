

using Product.Infrastructure.MongoDB;
using Product.Infrastructure.RabbitMQ;
using Product.Infrastructure.Repositories;
using Product.Infrastructure.Repositories.Interfaces;
using RabbitMQ.Client;


namespace Order.Api
{
    public static class AllServices
    {
        public static void registers(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddSingleton<MongoDbService>();
            services.AddHostedService<ProductServiceConsumer>();
        
        }
    }
}
