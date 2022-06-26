using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
=======
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
=======
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
>>>>>>> Bonet
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parafarmacia.Data;
using parafarmacia.Models;

namespace parafarmacia.Controllers
{
<<<<<<< HEAD
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
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
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
=======
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
=======
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
>>>>>>> Bonet
        {
            _context = context;
            _userManager = userManager;
        }

<<<<<<< HEAD
        // GET: Users
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        [Authorize(Roles = "Admin")]
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
=======
        // GET: Orders
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        [Authorize(Roles = "Admin, User")]
>>>>>>> Bonet
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
=======
            var users = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
=======
            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
>>>>>>> Bonet
            {
                return NotFound();
            }

<<<<<<< HEAD
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
            return View(orders);
        }

        // GET: Orders/Create
=======
            return View(users);
        }

        // GET: Users/Create
        [Authorize(Roles = "Admin")]
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
        public IActionResult Create()
        {
            return View();
        }

<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,NIF")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }

        // GET: Orders/Edit/5
=======
        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Email,Role,Name")] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = "Admin")]
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,NIF")] Orders orders)
        {
            if (id != orders.Id)
=======
            var users = await _context.User.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Role,Name")] Users users)
        {
            if (id != users.Id)
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
                    _context.Update(orders);
=======
                    _context.Update(users);
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
                    if (!OrdersExists(orders.Id))
=======
                    if (!UsersExists(users.Id))
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
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
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
            return View(orders);
        }

        // GET: Orders/Delete/5
=======
            return View(users);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "Admin")]
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
=======
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
                var user = await _userManager.GetUserAsync(User);

                var cart = await _context.Carts.Where(c => c.UserFK == user.User).Include(c => c.ProductCartList).ThenInclude(pc => pc.Product).OrderByDescending(c => c.Id).FirstOrDefaultAsync();

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

                    _context.Add(orders);

                    //create a new shopping cart
                    var newCart = new Carts { Total = 0, UserFK = user.User };
                    _context.Add(newCart);

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }

            }
            return RedirectToAction("MyCart", "Carts");
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "Admin, User")]
>>>>>>> Bonet
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
=======
            var users = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
=======
            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
>>>>>>> Bonet
            {
                return NotFound();
            }

<<<<<<< HEAD
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
=======
>>>>>>> Bonet
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
<<<<<<< HEAD
        [ValidateAntiForgeryToken]
=======
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
>>>>>>> Bonet
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
<<<<<<< HEAD
=======
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.User.FindAsync(id);
            _context.User.Remove(users);


            var applicationUser = await _userManager.GetUserAsync(User);
            await _userManager.DeleteAsync(applicationUser);

>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
=======
>>>>>>> Bonet
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

<<<<<<< HEAD
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
=======
        private bool UsersExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
=======
        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
>>>>>>> Bonet
        }
    }
}
