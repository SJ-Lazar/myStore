using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myStore.Data;
using myStore.Models;
using Newtonsoft.Json;

namespace myStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }


            

            

            var sc = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Session.GetString("ShoppingCartSession"));

           sc.CartItem = _context.CartItem.ToList().FindAll(x => x.ShoppingCartId == sc.ShoppingCartId);

            var cartview = new List<CartView>();
           
            foreach(var item in sc.CartItem)
            {
                cartview.Add(new CartView()
                {
                    CartItem = item,
                    Product = _context.Products.FirstOrDefault( x => x.ProductId == item.ProductId)
                });
                
            }
               
            
           

            ViewData["cartView"] = cartview;
            ViewData["colors"] = _context.Color.ToList();
            ViewData["sizes"] = _context.Size.ToList();

            HttpContext.Session.Clear();
            return View(order);
        }

        public IActionResult Create()
        {
            var sc = new ShoppingCart();

            sc = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Session.GetString("ShoppingCartSession"));


            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value; // will give the user's userId



            var order = new Order();
            order.ShoppingCartId = sc.ShoppingCartId;
            order.OrderNumber = "OR" + order.ShoppingCartId;
            order.CustomerId = userId ;
            order.IsCleared = true;


            HttpContext.Session.Clear();
            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderNumber,CustomerId,ShoppingCartId,IsCleared")] Order order)
        {
          

            if (ModelState.IsValid)
                {
                    _context.Add(order);
                   await _context.SaveChangesAsync();
                    return RedirectToAction("Details","Orders");
                }
            
           
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id); 
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderNumber,CustomerId,ShoppingCartId,IsCleared")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }

        public ActionResult GetCustomerOrders(string id)
        {        
            return View(_context.Order.ToList().FindAll(x => x.CustomerId == id));
        }
    }
}
