
using Order.Infrastructure.Entities;

namespace Order.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task <List<OrderEntity>> GetAllOrdersAsync();
        public Task<OrderEntity> GetOrderByIdAsync(int id);
        public Task<bool>DeleteOrderByIdAsync(int id);
    }
}
