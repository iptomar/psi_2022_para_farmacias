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
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Orders
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> MyOrders()
        {
            var applicationUser = await _userManager.GetUserAsync(User);

            var result = await _context.Orders.Where(o=>o.User==applicationUser.User).ToListAsync();

            return View("MyOrders", result);
        }

        // GET: Orders/Details/5
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            ViewBag.data = _context.OrderProduct.Where(op => op.OrderFK == orders.Id).Include(op => op.Product);
            ViewBag.total = _context.Carts.Where(c => c.Id == orders.Cart).First().Total;
            return View(orders);
        }

        // GET: Carts/Finalize
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Finalize()
        {
            var user = await _userManager.GetUserAsync(User);

            var cart = await _context.Carts.Where(c => c.UserFK == user.User).Include(c => c.ProductCartList).ThenInclude(pc => pc.Product).OrderByDescending(c => c.Id).FirstOrDefaultAsync();

            if (cart == null)
            {
                return RedirectToAction("MyCart", "Carts");
            }

            if (await _context.ProductCart.Where(pc => pc.CartFK == cart.Id).AnyAsync())
            {
                return View();
            }

            return RedirectToAction("MyCart", "Carts");

        }

        // POST: Carts/Submit
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit([Bind("Address,NIF")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = await _userManager.GetUserAsync(User);

                var cart = await _context.Carts.Where(c => c.UserFK == applicationUser.User).Include(c => c.ProductCartList).ThenInclude(pc => pc.Product).OrderByDescending(c => c.Id).FirstOrDefaultAsync();

                if (cart == null)
                {
                    return RedirectToAction("MyCart", "Carts");
                }

                if (await _context.ProductCart.Where(pc => pc.CartFK == cart.Id).AnyAsync())
                {
                    foreach (var pc in cart.ProductCartList.ToList())
                    {
                        orders.OrderProductList.Add(
                            new OrderProduct { Order = orders, Price = pc.Price, Product = pc.Product, Quantity = pc.Quantity }
                            );
                    }
                    orders.Cart = cart.Id;
                    orders.User = applicationUser.User;
                    _context.Add(orders);

                    //create a new shopping cart
                    var newCart = new Carts { Total = 0, UserFK = applicationUser.User };
                    _context.Add(newCart);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("MyOrders", "Orders");

                }

            }
            return RedirectToAction("MyCart", "Carts");
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
