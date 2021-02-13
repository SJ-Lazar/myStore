using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myStore.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }      
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }   
    }
}
