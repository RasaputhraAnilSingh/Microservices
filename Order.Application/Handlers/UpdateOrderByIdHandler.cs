using MediatR;
using Order.Application.Commands;
using Order.Application.DTOs;
using Order.Infrastructure.Entities;
using Order.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Handlers
{
    public class UpdateOrderByIdHandler : IRequestHandler<UpdateOrderByIdCommand, CreateOrderDTO>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<CreateOrderDTO> Handle(UpdateOrderByIdCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new OrderEntity
            {
                Id = request.Id,
                Name = request.Name,
                Quantity = request.Quantity,
                Price = request.Price
            };
            var updateEntity = await _orderRepository.UpdateOrderById(UpdateEntity);
            var createOrderDto = new CreateOrderDTO
            {
                Id= updateEntity.Id,
                Name = updateEntity.Name,
                Quantity = updateEntity.Quantity,
                Price = updateEntity.Price
            };
            return createOrderDto;
        }
    }
}
