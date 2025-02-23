using Article.Api.Model;
using Article.Api.Repository.Interface;

namespace Article.Api.Repository
{
    public class OrderRepository : List<OrderModel>,IOrderRepository
    {
        private readonly static List<OrderModel> _articles = populate();

        private static List<OrderModel> populate()
        {
            return new List<OrderModel>
            {
                new OrderModel { Id = 100,Title = "Nijam" },
                new OrderModel { Id = 200, Title = "Ataadu" },
                new OrderModel { Id = 300, Title = "Pokiri"}
            };

        }

        public bool deleteArticleById(int id)
        {
            _articles.RemoveAt(id);
            return true;
        }

        public List<OrderModel> getAllArticles()
        {
            return _articles;
        }

        public OrderModel getArticleById(int id)
        {
            return _articles[id];
        }
    }
}
