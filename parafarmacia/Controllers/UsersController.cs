using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
=======
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
=======
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parafarmacia.Data;
using parafarmacia.Models;

namespace parafarmacia.Controllers
{
<<<<<<< HEAD
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
=======
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
        {
            _context = context;
            _userManager = userManager;
>>>>>>> Bonet
        }

        // GET: Users
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        [Authorize(Roles = "Admin")]
<<<<<<< HEAD
=======
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var users = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
=======
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
=======
            var users = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
            {
                return NotFound();
            }

<<<<<<< HEAD
=======
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
            return View(orders);
        }

        // GET: Orders/Create
=======
>>>>>>> Bonet
            return View(users);
        }

        // GET: Users/Create
        [Authorize(Roles = "Admin")]
<<<<<<< HEAD
=======
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
        public IActionResult Create()
        {
            return View();
        }

<<<<<<< HEAD
=======
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
>>>>>>> Bonet
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
<<<<<<< HEAD
=======
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
=======
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
>>>>>>> Bonet
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
<<<<<<< HEAD
=======
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
<<<<<<< HEAD
                    _context.Update(users);
=======
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
                    _context.Update(orders);
=======
                    _context.Update(users);
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
<<<<<<< HEAD
                    if (!UsersExists(users.Id))
=======
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
                    if (!OrdersExists(orders.Id))
=======
                    if (!UsersExists(users.Id))
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
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
<<<<<<< HEAD
=======
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
            return View(orders);
        }

        // GET: Orders/Delete/5
=======
>>>>>>> Bonet
            return View(users);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "Admin")]
<<<<<<< HEAD
=======
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var users = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
=======
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
=======
            var users = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
            {
                return NotFound();
            }

<<<<<<< HEAD
=======
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
=======
>>>>>>> Bonet
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
<<<<<<< HEAD
=======


            var applicationUser = await _userManager.GetUserAsync(User);
            await _userManager.DeleteAsync(applicationUser);

>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

<<<<<<< HEAD
        private bool UsersExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
=======
<<<<<<< HEAD:parafarmacia/Controllers/OrdersController.cs
        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
=======
        private bool UsersExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
>>>>>>> Bonet:parafarmacia/Controllers/UsersController.cs
>>>>>>> Bonet
        }
    }
}
