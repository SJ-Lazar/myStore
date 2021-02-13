using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace myStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      
      
        public DbSet<Product> Products {get;set;}

        public DbSet<myStore.Models.ShoppingCart> ShoppingCart { get; set; }

        public DbSet<myStore.Models.CartItem> CartItem { get; set; }

        public DbSet<myStore.Models.Category> Category { get; set; }

        public DbSet<myStore.Models.Color> Color { get; set; }

        public DbSet<myStore.Models.Size> Size { get; set; }

        public DbSet<myStore.Models.Tag> Tag { get; set; }

        public DbSet<myStore.Models.ProductSpec> ProductSpec { get; set; }

        public DbSet<myStore.Models.Brand> Brand { get; set; }

        public DbSet<myStore.Models.Stock> Stock { get; set; }

        public DbSet<myStore.Models.Customer> Customer { get; set; }

        public DbSet<myStore.Models.Order> Order { get; set; }

        public DbSet<myStore.Models.Address> Address { get; set; }

        

   

    }
}
