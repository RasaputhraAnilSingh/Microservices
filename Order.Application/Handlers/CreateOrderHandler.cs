using MediatR;
using Order.Application.Commands;
using Order.Infrastructure.Entities;
using Order.Infrastructure.RabbitMQ;
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
        private readonly OrderPublisherService _orderPublisherService;

        public CreateOrderHandler(IOrderRepository orderRepository,OrderPublisherService orderPublisherService)
        {
            _orderRepository = orderRepository;
            _orderPublisherService = orderPublisherService;
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
                 orderId = await _orderRepository.CreateOrderAsync(order);
                if (orderId != 0 || orderId != null)
                { 
                    await _orderPublisherService.InitializeConnectionAsync();
                    await _orderPublisherService.PublishOrderEventAsync(order);

                }
            }
            catch(Exception ex)
            {

            }
            return orderId;
        }
    }
}
