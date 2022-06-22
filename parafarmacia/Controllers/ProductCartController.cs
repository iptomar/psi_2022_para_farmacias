using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parafarmacia.Data;
using parafarmacia.Models;

namespace parafarmacia.Controllers
{
    public class ProductCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductCartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ProductCart
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductCart.Include(p => p.Cart).Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductCart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCart = await _context.ProductCart
                .Include(p => p.Cart)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCart == null)
            {
                return NotFound();
            }

            return View(productCart);
        }

        // POST: ProductCart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Create([Bind("Quantity,ProductFK")] ProductCart productCart)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                Carts cart;

                if (!await _context.Carts.Where(c => c.User.Id == user.User).AnyAsync())
                {
                    // cria novo carrinho
                    cart = new Carts
                    {
                        Total = 0,
                        UserFK = user.User
                    };
                    await _context.AddAsync(cart);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // usa o último carrinho criado
                    cart = await _context.Carts.OrderByDescending(c => c.Id).LastOrDefaultAsync(c => c.UserFK == user.User);
                }

                Products product = await _context.Products.Where(p => p.Id == productCart.ProductFK).FirstOrDefaultAsync();


                var existingProductCart = await _context.ProductCart.Where(pc => pc.CartFK == cart.Id && pc.Cart.UserFK==user.User && pc.ProductFK == product.Id).FirstOrDefaultAsync();
                if (existingProductCart!=null)
                {
                    // a row with this product and cart already exists
                    // increase quantity instead
                    existingProductCart.Quantity += 1;
                    existingProductCart.Price = product.Price * productCart.Quantity;

                   _context.Update(existingProductCart);
                }
                else
                {
                    // new row
                    productCart.CartFK = cart.Id;
                    productCart.Price = product.Price * productCart.Quantity;

                    await _context.AddAsync(productCart);
                }

                // set the user cart to the same price
                cart.Total += product.Price * productCart.Quantity;
                _context.Update(cart);

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProductCart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCart = await _context.ProductCart.FindAsync(id);
            if (productCart == null)
            {
                return NotFound();
            }
            ViewData["CartFK"] = new SelectList(_context.Carts, "Id", "Id", productCart.CartFK);
            ViewData["ProductFK"] = new SelectList(_context.Products, "Id", "Description", productCart.ProductFK);
            return View(productCart);
        }

        // POST: ProductCart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Price,ProductFK,CartFK")] ProductCart productCart)
        {
            if (id != productCart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCartExists(productCart.Id))
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
            ViewData["CartFK"] = new SelectList(_context.Carts, "Id", "Id", productCart.CartFK);
            ViewData["ProductFK"] = new SelectList(_context.Products, "Id", "Description", productCart.ProductFK);
            return View(productCart);
        }

        // GET: ProductCart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCart = await _context.ProductCart
                .Include(p => p.Cart)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCart == null)
            {
                return NotFound();
            }

            return View(productCart);
        }

        // POST: ProductCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCart = await _context.ProductCart.FindAsync(id);
            _context.ProductCart.Remove(productCart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCartExists(int id)
        {
            return _context.ProductCart.Any(e => e.Id == id);
        }
    }
}
