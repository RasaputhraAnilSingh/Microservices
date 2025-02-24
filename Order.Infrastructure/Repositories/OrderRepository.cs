
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Order.Infrastructure.Entities;
using Order.Infrastructure.Repositories.Interfaces;
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
                string sql = "insert into orders(Name,Quantity,Price)values(@Name,@Quantity,@Price);SELECT CAST(SCOPE_IDENTITY() as int)";
                int orderId = await connection.QueryFirstOrDefaultAsync<int>(sql,new {order.Name,order.Quantity,order.Price});
                connection.Close();
                return orderId;

            }
        }

        //public async Task<bool> DeleteOrderByIdAsync(int id)
        //{
        //    return await Task.Run(() =>
        //    {
        //        _articles.RemoveAt(id);
        //        return true;
        //    });

        //}

        public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
        {
            IEnumerable<OrderEntity> Orders = new List<OrderEntity>();
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
                {
                    connection.Open();
                    Orders = await connection.QueryAsync<OrderEntity>("select * from Orders");
                    connection.Close();
                }
            }
            catch (Exception ex) { }
            return Orders;



        }

        //public async Task<OrderEntity> GetOrderByIdAsync(int id)
        //{
        //    return await Task.Run(() =>
        //    {
        //        return _articles[id];
        //    });
            
        //}
    }
}
