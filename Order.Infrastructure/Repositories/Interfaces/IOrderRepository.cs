﻿
using Order.Infrastructure.Entities;

namespace Order.Infrastructure.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<OrderEntity>> GetAllOrdersAsync();
        public Task<OrderEntity> UpdateOrderById(OrderEntity orderEntity);
        public Task<bool> DeleteOrderByIdAsync(int id);
        public Task<int> CreateOrderAsync(OrderEntity order);
        public Task<OrderEntity> GetOrderByIdAsync(int Id);
        
    }
}
