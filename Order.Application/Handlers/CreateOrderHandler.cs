using MediatR;
using Order.Application.Commands;
using Order.Infrastructure.Entities;
using Order.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Handlers
{

    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            int orderId = 0;
            var order = new OrderEntity
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Name = request.Name,
                Price = request.Price,
            };
            try
            {
                 orderId =  await _orderRepository.CreateOrderAsync(order);
            }
            catch(Exception ex)
            {

            }
            return orderId;
        }
    }
}
