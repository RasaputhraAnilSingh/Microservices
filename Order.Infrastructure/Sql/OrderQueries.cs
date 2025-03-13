

namespace Order.Infrastructure.Sql
{
    public class OrderQueries
    {
        public static string CreateOrder = "insert into orders(Name,Quantity,Price)values(@Name,@Quantity,@Price);SELECT CAST(SCOPE_IDENTITY() as int)";
        public static string GetAllOrders = "select * from Orders";
        public static string GetOrderById = "select * from Orders where Id = @ID";
        public static string DeleteOrderById = "DeleteOrderById";
        public static string UpdateOrderById = "UpdateOrderById";
    }

}
