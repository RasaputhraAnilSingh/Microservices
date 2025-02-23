
using Product.Infrastructure.Entities;

namespace Product.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<ProductEntity>> GetAllProductsAsync();
        public Task<ProductEntity> GetProductByIdAsync(int id);
        public Task<bool> DeleteProductByIdAsync(int id);
    }
}
