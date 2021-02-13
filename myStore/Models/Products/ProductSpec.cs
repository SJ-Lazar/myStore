using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myStore.Models
{
    public class ProductSpec
    {
        public int ProductSpecId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int TagId { get; set; }
        public int BrandId { get; set; }

        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
