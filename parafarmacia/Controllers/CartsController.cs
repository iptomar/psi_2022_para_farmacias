using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parafarmacia.Data;
using parafarmacia.Models;

namespace parafarmacia.Controllers
{
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Carts.Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carts = await _context.Carts
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carts == null)
            {
                return NotFound();
            }

            return View(carts);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            ViewData["UserFK"] = new SelectList(_context.User, "Id", "Email");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Total,UserFK")] Carts carts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserFK"] = new SelectList(_context.User, "Id", "Email", carts.UserFK);
            return View(carts);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carts = await _context.Carts.FindAsync(id);
            if (carts == null)
            {
                return NotFound();
            }
            ViewData["UserFK"] = new SelectList(_context.User, "Id", "Email", carts.UserFK);
            return View(carts);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Total,UserFK")] Carts carts)
        {
            if (id != carts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartsExists(carts.Id))
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
            ViewData["UserFK"] = new SelectList(_context.User, "Id", "Email", carts.UserFK);
            return View(carts);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carts = await _context.Carts
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carts == null)
            {
                return NotFound();
            }

            return View(carts);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carts = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(carts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartsExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}