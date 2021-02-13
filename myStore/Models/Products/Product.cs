using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myStore.Models
{
    public class Product
    {
        [DisplayName("Id")]
        [Key]
        public int ProductId { get; set; }

        [DisplayName("Serial Number")]
        [Required]
        public string SerialNumber { get; set; }

        [DisplayName("Bar Code")]
        [Required]
        public int BarCode { get; set; }

        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }

        [DisplayName("Description")]
        public string ProdcutDescription { get; set; }

        public decimal Price { get; set; }
        [DisplayName("Image Path")]
        public string ImagePath { get; set; }

    }
}
