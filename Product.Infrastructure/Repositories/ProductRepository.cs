
using Product.Infrastructure.Entities;
using Product.Infrastructure.Repositories.Interfaces;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly static List<ProductEntity> _writer = populate();

        private static List<ProductEntity> populate()
        {
            return new List<ProductEntity>
            {
                new ProductEntity { Id = 1000,Name = "AnilSingh" },
                new ProductEntity { Id = 2000, Name = "Trivikram" },
                new ProductEntity { Id = 3000, Name = "Puri"}
            };

        }
        public async Task<bool> DeleteProductByIdAsync(int id)
        {
           return await Task.Run(() =>
            {
                _writer.RemoveAt(id);
                return true;
            });
            
        }

        public async Task<List<ProductEntity>> GetAllProductsAsync()
        {
            return await Task.Run(() => { return _writer; });
        }

        public async Task<ProductEntity> GetProductByIdAsync(int id)
        {
            return await Task.Run(() => { return _writer[id]; });
        }
    }
}
