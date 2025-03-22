

using Order.Infrastructure.RabbitMQ;
using Order.Infrastructure.Repositories;
using Order.Infrastructure.Repositories.Interfaces;

namespace Order.Api
{
    public static class AllServices
    {
        public static void registers(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddSingleton<OrderPublisherService>();

        }
    }
}
