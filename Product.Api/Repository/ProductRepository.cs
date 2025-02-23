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
        public bool deleteWriterById(int id)
        {
            _writer.RemoveAt(id);
            return true;
        }

        public List<ProductModel> getAllWriter()
        {
           return _writer;
        }

        public ProductModel getWriterById(int id)
        {
            return _writer[id];
        }
    }
}
