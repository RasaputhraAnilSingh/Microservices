using MediatR;
using Order.Application.DTOs;
using Order.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Commands
{
    public class UpdateOrderByIdCommand :IRequest<CreateOrderDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity {  get; set; }
        public decimal Price { get; set; }

        public UpdateOrderByIdCommand(int Id,string Name,int Quantity,decimal Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
    }
}
