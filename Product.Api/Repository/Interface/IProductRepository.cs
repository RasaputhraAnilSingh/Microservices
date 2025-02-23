using Writer.Api.Model;

namespace Writer.Api.Repository.Interface
{
    public interface IProductRepository
    {
        public List<ProductModel> getAllProducts();
        public ProductModel getProductById(int id);
        public bool deleteProductById(int id);
    }
}
