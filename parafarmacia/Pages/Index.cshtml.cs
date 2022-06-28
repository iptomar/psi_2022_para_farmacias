using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using parafarmacia.Data;

namespace parafarmacia.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<Models.Products>? Products { get; set; }
        public IEnumerable<Models.Products>? AllProducts { get; set; }
        public IEnumerable<Models.Products>? LatestProducts { get; set; }
        public IEnumerable<Models.Products>? TopSellingProducts { get; set; }
        public IEnumerable<Models.ProductCategories>? Categories { get; set; }

        public async Task OnGet()
        {
            AllProducts = await _context.Products.Include(p => p.Category).ToListAsync();
            TopSellingProducts = _context.Products.OrderByDescending(p=> p.OrderProductList.Count()).Take(6);
            Products = await _context.Products.Include(p => p.Category).Take(8).ToListAsync();
            LatestProducts = _context.Products.OrderByDescending(p => p.Id).Take(6);
            Categories = await _context.ProductCategories.ToListAsync();
        }
    }
}
