using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myStore.Data;
using myStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace myStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
           var products = _context.Products.ToList();
            var stocks = _context.Stock.ToList();

            var bestSellerProducts = new List<Product>();

           var latestProducts = products.TakeLast(6).ToList();
           

           var bestSellersStock = stocks.ToList().FindAll(x => x.StockValue > 50);

           foreach(var item in bestSellersStock)
            {
                bestSellerProducts.Add(products.ToList().FirstOrDefault(x => x.ProductId == item.ProductId));
            }



            ViewData["latestProducts"] = latestProducts;
            ViewData["bestSellerProducts"] = bestSellerProducts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
