using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Commands;
using Order.Application.DTOs;
using Order.Application.Queries;

namespace Order.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       private readonly IMediator _mediatory;
        public OrderController(IMediator mediator) 
        {
            _mediatory = mediator;        
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO createOrder)
        {
            var command = new CreateOrderCommand(createOrder.Name,createOrder.Quantity,createOrder.ProductId,createOrder.Price);
            int orderId = await _mediatory.Send(command);
            return Ok(orderId);
        }
        [HttpGet("getAllOrders")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllOrdersQueries();
            var orders = await _mediatory.Send(query);
            return Ok(orders);
        }

        //[HttpGet("getOrderById/{id}")]
        //public async Task<IActionResult> GetbyID(int id)
        //{
        //    return Ok(await _orderRepository.GetOrderByIdAsync(id));
        //}

        //[HttpDelete("deleteOrderById/{id}")]
        //public async Task<IActionResult> delete(int id)
        //{
        //    return Ok(await _orderRepository.DeleteOrderByIdAsync(id));
        //}
    }
}
