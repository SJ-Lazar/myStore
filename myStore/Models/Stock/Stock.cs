using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myStore.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int StockValue { get; set; }
        public bool InStock { get; set; }
        public List<Product> Product { get; set; }
        public List<Color> Colors { get; set; }
        public List<Size> Sizes { get; set; }
    }

}
