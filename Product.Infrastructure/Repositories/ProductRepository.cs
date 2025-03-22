
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Product.Infrastructure.Entities;
using Product.Infrastructure.Repositories.Interfaces;
using Product.Infrastructure.SQLQueries;
using RabbitMQ.Client;
using System.Data;
using System.Runtime.InteropServices;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        private readonly static List<ProductEntity> _writer = populate();

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static List<ProductEntity> populate()
        {
            return new List<ProductEntity>
            {
                new ProductEntity { Id = 1,Name = "AnilSingh" },
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

        public async Task<bool> UpdateProductById(ProductEntity product)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<bool>(ProductQueries.Update,new
                {
                    Id = product.Id,
                    Quantity = product.Quantity
                });
                connection.Close();
                return result;
            }
        }
    }
}
