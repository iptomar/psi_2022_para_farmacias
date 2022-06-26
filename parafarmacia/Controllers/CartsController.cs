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
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Carts/MyCart
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> MyCart()
        {
            var user = await _userManager.GetUserAsync(User);

            var cart = await _context.Carts.Where(c => c.UserFK == user.User).Include(c => c.ProductCartList).ThenInclude(pc => pc.Product).OrderByDescending(c => c.Id).FirstOrDefaultAsync();

            if (cart == null)
            {
                cart = new Carts
                {
                    Total = 0,
                    UserFK = user.User,
                };

                _context.Add(cart);
                await _context.SaveChangesAsync();
            }

            return View(cart);
        }

    }
}
