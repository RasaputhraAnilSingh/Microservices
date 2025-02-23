using Microsoft.AspNetCore.Mvc;
using Product.Infrastructure.Repositories.Interfaces;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("getAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepository.GetAllProductsAsync());
        }

        [HttpGet("getProductById/{id}")]
        public async Task<IActionResult> GetbyID(int id)
        {
            return Ok(await _productRepository.GetProductByIdAsync(id));
        }

        [HttpDelete("deleteProductById/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            return Ok(await _productRepository.DeleteProductByIdAsync(id));
        }
    }

}
