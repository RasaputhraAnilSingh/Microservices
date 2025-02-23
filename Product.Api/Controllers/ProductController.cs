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
        [HttpGet("getAllWriters")]
        public IActionResult Get()
        {
            return Ok(_writerRepository.getAllWriter());
        }

        [HttpGet("getWriterById/{id}")]
        public IActionResult GetbyID(int id)
        {
            return Ok(_writerRepository.getWriterById(id));
        }

        [HttpDelete("deleteWriterById/{id}")]
        public IActionResult delete(int id)
        {
            return Ok(_writerRepository.deleteWriterById(id));
        }
    }

}
