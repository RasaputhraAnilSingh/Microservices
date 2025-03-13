
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Order.Infrastructure.Entities;
using Order.Infrastructure.Repositories.Interfaces;
using Order.Infrastructure.Sql;
using System.Data;


namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> CreateOrderAsync(OrderEntity order)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                int orderId = await connection.QueryFirstOrDefaultAsync<int>(OrderQueries.CreateOrder, new {order.Name,order.Quantity,order.Price});
                connection.Close();
                return orderId;

            }
        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"))) 
            {
                connection.Open();
                var result = await connection.QuerySingleAsync<bool>(OrderQueries.DeleteOrderById, new {@ID = id},commandType:CommandType.StoredProcedure);
                connection.Close();
                return result;
            }

        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
        {
            IEnumerable<OrderEntity> Orders = new List<OrderEntity>();
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
                {
                    connection.Open();
                    Orders = await connection.QueryAsync<OrderEntity>(OrderQueries.GetAllOrders);
                    connection.Close();
                }
            }
            catch (Exception ex) { }
            return Orders;



        }

        public async Task<OrderEntity> GetOrderByIdAsync(int Id)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                connection.Open();
                var orderEntity = await connection.QueryFirstOrDefaultAsync<OrderEntity>(OrderQueries.GetOrderById, new { @ID = Id });
                connection.Close();
                return orderEntity;
            }
        }

        public async Task<OrderEntity> UpdateOrderById(OrderEntity orderEntity)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var order = new
                {
                    @ID = orderEntity.Id,
                    @Name = orderEntity.Name,
                    @Quantity = orderEntity.Quantity,
                    @Price = orderEntity.Price
                };
                var result = await connection.QueryFirstOrDefaultAsync<OrderEntity>(OrderQueries.UpdateOrderById, order, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result;
            }
        }

        
    }
}
