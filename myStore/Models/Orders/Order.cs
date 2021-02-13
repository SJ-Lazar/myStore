using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerId { get; set; }
        public int ShoppingCartId { get; set; }
        public bool IsCleared { get; set; }     
    }
}
