using Writer.Api.Model;
using Writer.Api.Repository.Interface;

namespace Writer.Api.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly static List<ProductModel> _writer = populate();

        private static List<ProductModel> populate()
        {
            return new List<ProductModel>
            {
                new ProductModel { Id = 1000,Name = "AnilSingh" },
                new ProductModel { Id = 2000, Name = "Trivikram" },
                new ProductModel { Id = 3000, Name = "Puri"}
            };

        }
        public bool deleteProductById(int id)
        {
            _writer.RemoveAt(id);
            return true;
        }

        public List<ProductModel> getAllProducts()
        {
           return _writer;
        }

        public ProductModel getProductById(int id)
        {
            return _writer[id];
        }
    }
}
