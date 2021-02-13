using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myStore.Data;
using myStore.Models;
using Newtonsoft.Json;


namespace myStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> IndexTable()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
             
            var productDetailView = new ProductDetailView();
 
            var product = await _context.Products
              .FirstOrDefaultAsync(m => m.ProductId == id);


            List<Color> colors = new List<Color>();
            List<Size> sizes = _context.Size.ToList();

            //colors = _context.Color.ToList();
            //sizes = _context.Size.ToList();

            List<Stock> stocks = new List<Stock>();
            stocks = (_context.Stock.ToList().FindAll(m => m.ProductId == id));





            foreach(var item in stocks)
            {
                colors.Add(_context.Color.ToList().First(x => x.ColorId == item.ColorId));
            }
                
            
            
            ViewData["colors"] = colors;
            ViewData["sizes"] = sizes;
            ViewData["stocks"] = stocks;

            productDetailView.Product = product;
            //productDetailView.Stock = stocks;
            
            return View(productDetailView);
        }
        //GET: Stock
        public ActionResult GetCurrentStock(int? id)
        {
            var stock = _context.Stock.FirstOrDefault(x => x.StockId == id);

            var product = _context.Products
                .FirstOrDefault(m => m.ProductId == stock.ProductId);

            var color = _context.Color.FirstOrDefault(m => m.ColorId == stock.ColorId);
            var size = _context.Size.FirstOrDefault(m => m.SizeId == stock.SizeId);

            var productDetailView = new ProductDetailView();
            productDetailView.Product = product;
            productDetailView.Colors = color;
            productDetailView.Sizes = size;
            productDetailView.Stock = stock;

            return View(productDetailView);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,SerialNumber,BarCode,ProductName,ProdcutDescription,Price,ImagePath")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();


                return View(product);
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,SerialNumber,BarCode,ProductName,ProdcutDescription,Price,ImagePath")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        public ActionResult Index()
        {
            ProductSpec productView = new ProductSpec();

            productView.Categories = _context.Category.ToList();
            productView.Brands = _context.Brand.ToList();
            productView.Tags = _context.Tag.ToList();
            productView.Products = _context.Products.ToList();

            return View(productView);
        }
     
        public ActionResult FilterCategory(int id)
        {
            List<ProductSpec> productsSpec = new List<ProductSpec>();
            List<Product> products = new List<Product>();
            ProductSpec productView = new ProductSpec();

            productsSpec = _context.ProductSpec.ToList();

            
            foreach (var item in productsSpec.FindAll(x => x.CategoryId == id))
            {
                products.Add(_context.Products.FirstOrDefault(p => p.ProductId == item.ProductId));
            }

            productView.Products = products;
            productView.Categories = _context.Category.ToList();
            productView.Brands = _context.Brand.ToList();
            productView.Tags = _context.Tag.ToList();

            return View(productView);
        }

        public ActionResult FilterBrand(int id)
        {
            List<ProductSpec> productsSpec = new List<ProductSpec>();
            List<Product> products = new List<Product>();
            ProductSpec productView = new ProductSpec();

            productsSpec = _context.ProductSpec.ToList();


            foreach (var item in productsSpec.FindAll(x => x.BrandId == id))
            {
                products.Add(_context.Products.FirstOrDefault(p => p.ProductId == item.ProductId));
            }

            productView.Products = products;
            productView.Categories = _context.Category.ToList();
            productView.Brands = _context.Brand.ToList();
            productView.Tags = _context.Tag.ToList();

            return View(productView);
        }

        public ActionResult FilterTag(int id)
        {
            List<ProductSpec> productsSpec = new List<ProductSpec>();
            List<Product> products = new List<Product>();
            ProductSpec productView = new ProductSpec();

            productsSpec = _context.ProductSpec.ToList();


            foreach (var item in productsSpec.FindAll(x => x.TagId == id))
            {
                products.Add(_context.Products.FirstOrDefault(p => p.ProductId == item.ProductId));
            }

            productView.Products = products;
            productView.Categories = _context.Category.ToList();
            productView.Brands = _context.Brand.ToList();
            productView.Tags = _context.Tag.ToList();

            return View(productView);
        }

        public  ActionResult ProductsPortal()
        {
            return View();
        }
    }
}
