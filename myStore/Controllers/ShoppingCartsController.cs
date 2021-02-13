using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class ShoppingCartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartsController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public ActionResult AddToCart(int id)
        {         
            List<CartItem> cartItems = new List<CartItem>();         

            if (HttpContext.Session.GetString("cartSession") == null)
            {

                var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

                if(product != null)
                {
                    var stock = new Stock();
                    stock = _context.Stock.FirstOrDefault(s => s.ProductId == product.ProductId);

                    if(stock != null)
                    {
                        if(stock.StockValue > 0)
                        {
                            cartItems.Add(new CartItem()
                            {
                                CartItemId = product.ProductId,
                                ProductId = product.ProductId,
                                ColorId = stock.ColorId,
                                SizeId = stock.SizeId,
                                Quantity = 1,
                                TotalPrice = product.Price
                            });

                            stock.StockValue -= 1;
                            _context.SaveChanges();

                            HttpContext.Session.SetString("cartSession", JsonConvert.SerializeObject(cartItems));

                            HttpContext.Session.SetInt32("count", 1);
                        }
                       else
                        {
                            return RedirectToAction("OutOfStock", "Stocks");
                        }
                    }
                    else
                    {
                        return RedirectToAction("OutOfStock", "Stocks");
                    }
                }
            }
            else
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("cartSession"));

                if (cartItems.Exists(p => p.CartItemId == id))
                {
                    var cartItem = cartItems.Find(p => p.CartItemId == id);
                    var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

                  if(product != null)
                  {
                    var stock = new Stock();
                    stock = _context.Stock.FirstOrDefault(s => s.ProductId == product.ProductId);
                    if (stock != null)
                    {
                        if (stock.StockValue > 0)
                        {
                            cartItem.Quantity++;
                            cartItem.TotalPrice = cartItem.Quantity * product.Price;

                            stock.StockValue -= 1;
                            _context.SaveChanges();

                            HttpContext.Session.SetString("cartSession", JsonConvert.SerializeObject(cartItems));
                            HttpContext.Session.SetInt32("count", cartItems.Sum(q => q.Quantity));
                        }
                        else
                        {
                            return RedirectToAction("OutOfStock", "Stocks");
                        }
                    }
                  }
                }
                else
                {
                    var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
                    if (product != null)
                    {
                        var stock = new Stock();
                        stock = _context.Stock.FirstOrDefault(s => s.ProductId == product.ProductId);

                        if (stock != null)
                        {
                            if (stock.StockValue > 0)
                            {
                                cartItems.Add(new CartItem()
                                {
                                    
                                    ProductId = product.ProductId,
                                    ColorId = stock.ColorId,
                                    SizeId = stock.SizeId,
                                    Quantity = 1,
                                    TotalPrice = product.Price
                                });

                                stock.StockValue -= 1;
                                _context.SaveChanges();

                                HttpContext.Session.SetString("cartSession", JsonConvert.SerializeObject(cartItems));
                                HttpContext.Session.SetInt32("count", cartItems.Sum(q => q.Quantity));
                            }
                            else
                            {
                                return RedirectToAction("OutOfStock", "Stocks");
                            }
                        }
                        else
                        {
                            return RedirectToAction("OutOfStock", "Stocks");
                        }
                    }                
                }
            }

            return RedirectToAction("Index", "Products");
        }

        public ActionResult RemoveFromCart(int id)
        {
            List<CartItem> cartItems = new List<CartItem>();

            //CartItem cartItem = new CartItem(id);

            cartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("cartSession"));

            foreach (var item in cartItems)
            {
                if (item.ProductId == id)
                {
 
                    var stock = new Stock();
                    stock = _context.Stock.FirstOrDefault(s => s.ProductId == item.ProductId);

                    if (stock != null)
                    {                                              
                        stock.StockValue += item.Quantity;
                        _context.SaveChanges();                                          
                    }
                    cartItems.Remove(item); 
                   
                    HttpContext.Session.SetString("cartSession", JsonConvert.SerializeObject(cartItems));
                    HttpContext.Session.SetInt32("count", cartItems.Sum(q => q.Quantity));

                    break;
                }
            }
            return RedirectToAction("ViewCart");         
        }

        public List<CartView> getCartView()
        {
            List<CartView> cartview = new List<CartView>();

            List<CartItem> cartItems = new List<CartItem>();

            if (HttpContext.Session.GetString("cartSession") == null)
            {
                return cartview;
            }

            else
            {
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("cartSession"));
                if (cartItems == null)
                {
                    return cartview;
                }
                else
                {
                    foreach (CartItem cartItem in cartItems)
                    {

                        var product = _context.Products.FirstOrDefault(p => p.ProductId == cartItem.ProductId);

                        cartview.Add(new CartView()
                        {
                            CartItem = cartItem,
                            Product = product
                        });
                    }
                }
                return cartview;

            }
        }
        public ActionResult ViewCart()
        {
            
            return View(getCartView());
        }
        public IActionResult Create()
        {
            decimal total = GetTotal();

            if (total > 0)
            {
                var CartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("cartSession"));
                var shoppingCart = new ShoppingCart();
                List<CartView> cartview = new List<CartView>();

                shoppingCart.CartItem = CartItems;
                shoppingCart.Total = total;

                if (shoppingCart.CartItem != null && shoppingCart.Total > 0)
                {
                    ViewData["cartview"] = getCartView();
                    return View(shoppingCart);
                }

                return View();
            }
            return View();
        }
       
        public ActionResult QtyIncrease(int id)
        {

            List<CartItem> cartItems = new List<CartItem>();
            cartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("cartSession"));
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            var cartItem = cartItems.Find(p => p.CartItemId == id);

            var stock = new Stock();
            stock = _context.Stock.FirstOrDefault(s => s.ProductId == cartItem.ProductId);

            if (stock.StockValue > 0 )
            {
                cartItem.Quantity++;
                cartItem.TotalPrice = cartItem.Quantity * product.Price;
                stock.StockValue--;
                _context.SaveChanges();
                HttpContext.Session.SetString("cartSession", JsonConvert.SerializeObject(cartItems));
                HttpContext.Session.SetInt32("count", cartItems.Sum(q => q.Quantity));
            }
            else
            {
                return RedirectToAction("OutOfStock", "Stocks");
            }    
            return RedirectToAction("ViewCart");
        }

        public ActionResult QtyDecrease(int id)
        {

            List<CartItem> cartItems = new List<CartItem>();
            cartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("cartSession"));
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            var cartItem = cartItems.Find(p => p.CartItemId == id);

            var stock = new Stock();
            stock = _context.Stock.FirstOrDefault(s => s.ProductId == cartItem.ProductId);

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
                cartItem.TotalPrice = cartItem.Quantity * product.Price;
                stock.StockValue++;
                _context.SaveChanges();

            }
            else if(cartItem.Quantity <=0)
            {
                cartItem.Quantity = 1;
                cartItem.TotalPrice = cartItem.Quantity * product.Price;
            }

            HttpContext.Session.SetString("cartSession", JsonConvert.SerializeObject(cartItems));
            HttpContext.Session.SetInt32("count", cartItems.Sum(q => q.Quantity));
            return RedirectToAction("ViewCart");
        }

        public decimal GetTotal()
        {

            List<CartItem> cartItems = new List<CartItem>();
            cartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("cartSession"));

            decimal Total = 0;

            foreach (var item in cartItems)
            {
                Total += item.TotalPrice;
            }
          
            HttpContext.Session.SetString("cartSession", JsonConvert.SerializeObject(cartItems));

            return Total;
        }

        public ActionResult OrderReceipt()
        {
            var order = new Order();


            
            return View(order);
        }
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingCartId,Total")] ShoppingCart shoppingCart)
        {
             List<CartItem> cartItems = new List<CartItem>();
            cartItems = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("cartSession"));


            if (ModelState.IsValid)
            {
                _context.Add(shoppingCart);
                await _context.SaveChangesAsync();


                foreach (var cartItem in cartItems)
                {

                    _context.Add(new CartItem()
                    {
                        ShoppingCartId = shoppingCart.ShoppingCartId,
                        ProductId = cartItem.ProductId,
                        ColorId = cartItem.ColorId,
                        SizeId = cartItem.SizeId,
                        Quantity = cartItem.Quantity,
                        TotalPrice = cartItem.TotalPrice
                    });
                    _context.SaveChanges();
                }   

                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value; // will give the user's userId

                var order = new Order();
                order.ShoppingCartId = shoppingCart.ShoppingCartId;
                order.OrderNumber = "OR" + order.ShoppingCartId;
                order.CustomerId = userId;
                order.IsCleared = true;

                _context.Add(order);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetString("cartSession", JsonConvert.SerializeObject(null));
                HttpContext.Session.SetInt32("count",0);
                HttpContext.Session.SetString("ShoppingCartSession", JsonConvert.SerializeObject(shoppingCart));
                return RedirectToAction("Details", "Orders" , new { id = order.OrderId });
            }
            return View(cartItems);
        }
        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShoppingCart.ToListAsync());
        }
    }
}