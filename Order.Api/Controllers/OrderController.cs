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
        [HttpGet("getAllArticles")]
        public IActionResult Get()
        {
            return Ok(_articleRepository.getAllArticles());
        }

        [HttpGet("getArticleById/{id}")]
        public IActionResult GetbyID(int id)
        {
            return Ok(_articleRepository.getArticleById(id));
        }

        [HttpDelete("deleteArticleById/{id}")]
        public IActionResult delete(int id)
        {
            return Ok(_articleRepository.deleteArticleById(id));
        }
    }
}
