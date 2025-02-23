using Microsoft.AspNetCore.Mvc;
using Order.Infrastructure.Repositories.Interfaces;

namespace Order.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository) 
        {
            _orderRepository = orderRepository;        
        }
        [HttpGet("getAllOrders")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _orderRepository.GetAllOrdersAsync());
        }

        [HttpGet("getOrderById/{id}")]
        public async Task<IActionResult> GetbyID(int id)
        {
            return Ok(await _orderRepository.GetOrderByIdAsync(id));
        }

        [HttpDelete("deleteOrderById/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            return Ok(await _orderRepository.DeleteOrderByIdAsync(id));
        }
    }
}
