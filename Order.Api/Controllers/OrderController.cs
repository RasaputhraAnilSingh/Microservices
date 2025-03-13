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

        [HttpGet("getOrderById/{id}")]
        public async Task<IActionResult> GetbyID(int id)
        {
            var query = new GetOrderByIdQueries(id);
            var orderDto = await _mediatory.Send(query); return Ok(orderDto);
        }

        [HttpDelete("deleteOrderById/{id}")]
        public async Task<IActionResult> delete(int id)
        {

            var command = new DeleteOrderCommand(id);
            var result = await _mediatory.Send(command); return Ok(result);
        }

        [HttpPut("updateOrderById/{id}")]
        public async Task<IActionResult> UpdateOrderById(int id,[FromBody] UpdateDto updateDto)
        {
            var command = new UpdateOrderByIdCommand(id,updateDto.Name,updateDto.Quantity,updateDto.Price);
            var result = await _mediatory.Send(command);
            return Ok(result);
        }

    }
}
