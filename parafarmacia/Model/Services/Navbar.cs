using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using parafarmacia.Data;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace parafarmacia.Model.Services
{
    public class NavbarService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ClaimsPrincipal _user;

        public NavbarService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ClaimsPrincipal user)
        {
            _context = context;
            _userManager = userManager;
            _user = user;
        }

        public async Task<double> GetCartTotalAsync()
        {

            var user = await _userManager.GetUserAsync(_user);

            if (user == null) return 0;

            var lastCart = _context.Carts.Where(c => c.UserFK == user.User).OrderByDescending(c => c.Id).FirstOrDefault(c => c.UserFK == user.User);
            if (lastCart == null) return 0;

            return lastCart.Total;
        }

        public async Task<int> GetCartProductsSizeAsync()
        {
            var user = await _userManager.GetUserAsync(_user);

            if (user==null) return 0;

            var lastCart = _context.Carts.Where(c=>c.UserFK==user.User).OrderByDescending(c => c.Id).FirstOrDefault(c => c.UserFK == user.User);
            if (lastCart == null) return 0;

            var productTypes = _context.ProductCart.Where(pc => pc.CartFK == lastCart.Id && pc.Cart.UserFK==user.User).ToDictionary(pc => pc.ProductFK).ToList();

            return productTypes.Count();
        }
    }
}