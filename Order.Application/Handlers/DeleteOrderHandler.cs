using MediatR;
using Order.Application.Commands;
using Order.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderHandler(IOrderRepository orderRepository) { _orderRepository = orderRepository; }
        public async Task<bool> Handle(DeleteOrderCommand command,CancellationToken cancellationToken)
        {
            var IsDelete = await _orderRepository.DeleteOrderByIdAsync(command.OrderId);
            return IsDelete;
        }
    }
}
