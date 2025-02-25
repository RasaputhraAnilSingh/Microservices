using MediatR;
using Order.Application.DTOs;
using Order.Application.Queries;
using Order.Infrastructure.Repositories.Interfaces;

namespace Order.Application.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQueries, CreateOrderDTO>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIdHandler(IOrderRepository orderRepository) { _orderRepository = orderRepository; }
        public async Task<CreateOrderDTO>Handle(GetOrderByIdQueries request, CancellationToken cancellationToken)
        {
            var orderEntity = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            if(orderEntity != null)
            {
                return new CreateOrderDTO
                {
                    Id = orderEntity.Id,
                    Name = orderEntity.Name,
                    ProductId = orderEntity.ProductId,
                    Price = orderEntity.Price,
                    Quantity = orderEntity.Quantity
                };
            }
            else
            {
                return null;
            }
                  
        }
    }
}
