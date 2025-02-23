using Article.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Article.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       private readonly IOrderRepository _articleRepository;
        public OrderController(IOrderRepository articleRepository) 
        { 
            _articleRepository = articleRepository;        
        }
        [HttpGet("getAllOrders")]
        public IActionResult Get()
        {
            return Ok(_articleRepository.getAllOrders());
        }

        [HttpGet("getOrderById/{id}")]
        public IActionResult GetbyID(int id)
        {
            return Ok(_articleRepository.getOrderById(id));
        }

        [HttpDelete("deleteOrderById/{id}")]
        public IActionResult delete(int id)
        {
            return Ok(_articleRepository.deleteOrderById(id));
        }
    }
}
