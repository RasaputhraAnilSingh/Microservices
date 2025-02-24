using MediatR;
using Order.Application.DTOs;
using Order.Application.Queries;
using Order.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Handlers
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQueries,IEnumerable<CreateOrderDTO>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetAllOrdersHandler(IOrderRepository orderRepository) { _orderRepository = orderRepository; }
        public async Task<IEnumerable<CreateOrderDTO>> Handle(GetAllOrdersQueries queries,CancellationToken cancellation)
        {
            IEnumerable<CreateOrderDTO> Orders = new List<CreateOrderDTO>();
            try
            {
                var orders = await _orderRepository.GetAllOrdersAsync();
                Orders = orders.Select(order => new CreateOrderDTO
                {
                    Id = order.Id,
                    Name = order.Name,
                    Quantity = order.Quantity,
                    Price = order.Price,
                    ProductId = order.ProductId
                });
            }
            catch (Exception ex) { }
            return Orders;
        }
    }
}
