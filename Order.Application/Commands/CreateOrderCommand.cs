

using MediatR;

namespace Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<int> 
    {
        public string Name { get; set; }
        public int Quantity {  get; set; }
        public int ProductId {  get; set; }
        public decimal Price {  get; set; }

        public CreateOrderCommand(string name, int quantity, int productId, decimal price)
        {
            Name = name;
            Quantity = quantity;
            ProductId = productId;
            Price = price;
        }
    }
}
