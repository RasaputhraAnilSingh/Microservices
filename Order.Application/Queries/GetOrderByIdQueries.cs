using MediatR;
using Order.Application.DTOs;

namespace Order.Application.Queries
{
    public class GetOrderByIdQueries : IRequest<CreateOrderDTO>
    {
        public int OrderId {  get; set; }
        public GetOrderByIdQueries( int orderId) { 
        
            OrderId = orderId;
        }
    }
}
