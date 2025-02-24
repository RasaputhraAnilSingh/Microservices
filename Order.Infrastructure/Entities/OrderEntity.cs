

namespace Order.Infrastructure.Entities
{
    public class OrderEntity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity {  get; set; }
        public int ProductId { get; set; }
    }
}
