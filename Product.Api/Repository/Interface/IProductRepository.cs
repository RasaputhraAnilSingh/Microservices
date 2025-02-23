using Writer.Api.Model;

namespace Writer.Api.Repository.Interface
{
    public interface IProductRepository
    {
        public List<ProductModel> getAllWriter();
        public ProductModel getWriterById(int id);
        public bool deleteWriterById(int id);
    }
}
