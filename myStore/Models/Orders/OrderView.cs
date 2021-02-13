using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myStore.Models.Orders
{
    public class OrderView
    {
        public Order Order { get; set; }
        public List<Product> Products { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Customer Customer { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
