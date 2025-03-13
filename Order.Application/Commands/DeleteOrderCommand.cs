using MediatR;

namespace Order.Application.Commands
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int OrderId {  get; set; }
        public DeleteOrderCommand(int id) { OrderId = id; }
    }
}
