using Article.Api.Model;

namespace Article.Api.Repository.Interface
{
    public interface IOrderRepository
    {
        public List<OrderModel> getAllArticles();
        public OrderModel getArticleById(int id);
        public bool deleteArticleById(int id);
    }
}
