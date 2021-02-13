using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myStore.Models
{
    public class CartView
    {
        public Product Product { get; set; }
        public CartItem CartItem { get; set; }     
    }
}
