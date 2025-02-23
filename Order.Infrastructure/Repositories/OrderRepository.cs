
using Order.Infrastructure.Entities;
using Order.Infrastructure.Repositories.Interfaces;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly static List<OrderEntity> _articles = populate();

        private static List<OrderEntity> populate()
        {
            return new List<OrderEntity>
            {
                new OrderEntity { Id = 100,Title = "Nijam" },
                new OrderEntity { Id = 200, Title = "Ataadu" },
                new OrderEntity { Id = 300, Title = "Pokiri"}
            };

        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                _articles.RemoveAt(id);
                return true;
            });
            
        }

        public async Task<List<OrderEntity>> GetAllOrdersAsync()
        {
            return await Task.Run(() =>
            {
                return _articles;
            });
            
        }

        public async Task<OrderEntity> GetOrderByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                return _articles[id];
            });
            
        }
    }
}
