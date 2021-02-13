using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myStore.Data;
using myStore.Models;

namespace myStore.Controllers
{
    public class ProductSpecsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductSpecsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductSpecs
        public async Task<IActionResult> Index()
        {

            return View(await _context.ProductSpec.ToListAsync());
        }

        // GET: ProductSpecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSpec = await _context.ProductSpec
                .FirstOrDefaultAsync(m => m.ProductSpecId == id);
            if (productSpec == null)
            {
                return NotFound();
            }

            return View(productSpec);
        }

        // GET: ProductSpecs/Create
        public IActionResult Create()
        {
            List<Product> products = _context.Products.ToList();
            List<Category> categories = _context.Category.ToList();          
            List<Tag> tags = _context.Tag.ToList();
            List<Brand> brands = _context.Brand.ToList();
            ProductSpec productSpecs = new ProductSpec();

            productSpecs.Products = products;
            productSpecs.Categories = categories;        
            productSpecs.Tags = tags;
            productSpecs.Brands = brands;

            return View(productSpecs);
        }

        // POST: ProductSpecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductSpecId,ProductId,CategoryId,TagId,BrandId")] ProductSpec productSpec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSpec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productSpec);
        }

        // GET: ProductSpecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSpec = await _context.ProductSpec.FindAsync(id);
            if (productSpec == null)
            {
                return NotFound();
            }
            return View(productSpec);
        }

        // POST: ProductSpecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductSpecId,ProductId,categoryId,TagId,BrandId")] ProductSpec productSpec)
        {
            if (id != productSpec.ProductSpecId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSpec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSpecExists(productSpec.ProductSpecId))
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
            return View(productSpec);
        }

        // GET: ProductSpecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSpec = await _context.ProductSpec
                .FirstOrDefaultAsync(m => m.ProductSpecId == id);
            if (productSpec == null)
            {
                return NotFound();
            }

            return View(productSpec);
        }

        // POST: ProductSpecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSpec = await _context.ProductSpec.FindAsync(id);
            _context.ProductSpec.Remove(productSpec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSpecExists(int id)
        {
            return _context.ProductSpec.Any(e => e.ProductSpecId == id);
        }

      
    }
}
