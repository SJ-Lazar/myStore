using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myStore.Models
{


    public class ProductDetailView
    {

        public Product Product { get; set; }
        public Color Colors { get; set; }
        public Size Sizes { get; set; }
       public Stock Stock { get; set; }

    }
}
