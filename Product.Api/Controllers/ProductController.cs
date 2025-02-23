using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Writer.Api.Repository.Interface;

namespace Writer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _writerRepository;
        public ProductController(IProductRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }
        [HttpGet("getAllProducts")]
        public IActionResult Get()
        {
            return Ok(_writerRepository.getAllProducts());
        }

        [HttpGet("getProductById/{id}")]
        public IActionResult GetbyID(int id)
        {
            return Ok(_writerRepository.getProductById(id));
        }

        [HttpDelete("deleteProductById/{id}")]
        public IActionResult delete(int id)
        {
            return Ok(_writerRepository.deleteProductById(id));
        }
    }

}
