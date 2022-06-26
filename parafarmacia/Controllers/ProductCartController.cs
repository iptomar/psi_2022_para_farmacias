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
                    cart = await _context.Carts.Where(c => c.UserFK == user.User).OrderByDescending(c => c.Id).FirstOrDefaultAsync();
                }

                Products product = await _context.Products.Where(p => p.Id == productCart.ProductFK).FirstOrDefaultAsync();


                var existingProductCart = await _context.ProductCart.Where(pc => pc.CartFK == cart.Id && pc.Cart.UserFK == user.User && pc.ProductFK == product.Id).FirstOrDefaultAsync();
                if (existingProductCart != null)
                {
                    // a row with this product and cart already exists
                    // increase quantity instead
                    existingProductCart.Quantity += 1;
                    existingProductCart.Price += product.Price * productCart.Quantity;

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

        // POST: ProductCart/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Edit([Bind("Id,Quantity")] ProductCart productCartBefore)
        {

            var productCart = await _context.ProductCart.Where(pc => pc.Id == productCartBefore.Id).Include(pc=>pc.Product).Include(pc=>pc.Cart).FirstOrDefaultAsync();

            var addedQuantity = productCartBefore.Quantity - productCart.Quantity;

            productCart.Quantity = productCartBefore.Quantity;
            productCart.Price= productCart.Product.Price * productCart.Quantity;
            productCart.Cart.Total+= productCart.Product.Price * addedQuantity;
            
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
            return RedirectToAction("MyCart", "Carts");
        }

        // POST: ProductCart/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteConfirmed([Bind("Id")] ProductCart productCartBefore)
        {
            var productCart = await _context.ProductCart.Where(pc=>pc.Id==productCartBefore.Id).Include(pc=>pc.Product).FirstOrDefaultAsync();
            _context.ProductCart.Remove(productCart);

            // update cart total price
            var user = await _userManager.GetUserAsync(User);
            var cart = await _context.Carts.Where(c => c.UserFK == user.User).OrderByDescending(c=>c.Id).FirstOrDefaultAsync();
            cart.Total-= productCart.Quantity * productCart.Product.Price;

            _context.Carts.Update(cart);

            await _context.SaveChangesAsync();
            return RedirectToAction("MyCart", "Carts");
        }

        private bool ProductCartExists(int id)
        {
            return _context.ProductCart.Any(e => e.Id == id);
        }
    }
}
