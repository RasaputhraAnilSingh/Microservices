using Article.Api.Model;

namespace Article.Api.Repository.Interface
{
    public interface IOrderRepository
    {
        public List<OrderModel> getAllOrders();
        public OrderModel getOrderById(int id);
        public bool deleteOrderById(int id);
    }
}
