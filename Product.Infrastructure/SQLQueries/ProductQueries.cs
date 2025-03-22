using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.SQLQueries
{
    public class ProductQueries
    {
        public static string Update = @"

        update Items set 
Quantity = Quantity - @quantity where Id = @Id;

        ";
    }
}
