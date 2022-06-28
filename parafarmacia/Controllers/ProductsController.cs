using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parafarmacia.Data;
using parafarmacia.Models;

namespace parafarmacia.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public static IWebHostEnvironment _environment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;

        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);

            ViewBag.categories = _context.ProductCategories.ToList();
            return View(await applicationDbContext.ToListAsync());
        }

        // Post: Products/ByCategory
        [HttpPost]
        public async Task<IActionResult> ByCategory([Bind("Id")] ProductCategories category)
        {
            var applicationDbContext = _context.Products.Where(p=>p.CategoryFK==category.Id).Include(p => p.Category);

            ViewBag.categories = _context.ProductCategories.ToList();
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CategoryFK"] = new SelectList(_context.ProductCategories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,CategoryFK")] Products products, IFormFile Image)
        {
            if (ModelState.IsValid)
            {

                //use default image
                if (Image == null || !Image.ContentType.Contains("image"))
                {
                    products.Image = "default.png";

                }
                else
                { // user inserted image
                    Guid g= Guid.NewGuid();

                    string extensao = Path.GetExtension(Image.FileName).ToLower();

                    products.Image = g.ToString() + extensao;

                    var fileStream = new FileStream(_environment.WebRootPath + "/img/products/" + g.ToString() + extensao, FileMode.Create);
                    await Image.CopyToAsync(fileStream);
                }

                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryFK"] = new SelectList(_context.ProductCategories, "Id", "Name", products.CategoryFK);
            return View(products);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryFK"] = new SelectList(_context.ProductCategories, "Id", "Name", products.CategoryFK);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,CategoryFK")] Products products, IFormFile Image)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null){
                        if (Image.ContentType.Contains("image"))
                        {
                            Guid g = Guid.NewGuid();

                            string extensao = Path.GetExtension(Image.FileName).ToLower();

                            products.Image = g.ToString() + extensao;

                            var fileStream = new FileStream(_environment.WebRootPath + "/img/products/" + g.ToString() + extensao, FileMode.Create);
                            await Image.CopyToAsync(fileStream);

                            _context.Update(products);
                            await _context.SaveChangesAsync();
                        }
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
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
            ViewData["CategoryFK"] = new SelectList(_context.ProductCategories, "Id", "Name", products.CategoryFK);
            return View(products);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
