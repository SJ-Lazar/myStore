
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace myStore.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }

        public List<CartItem> CartItem { get; set; }

        public decimal Total { get; set; }

       

    }
}
