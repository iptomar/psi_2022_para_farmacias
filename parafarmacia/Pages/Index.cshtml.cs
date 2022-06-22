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
        public IEnumerable<Models.Products>? LatestProducts { get; set; }
        public Dictionary<Models.Products, int>? TopSellingProducts { get; set; }
        public IEnumerable<Models.ProductCategories>? Categories { get; set; }

        public async Task OnGet()
        {
            Products = await _context.Products.Include(p => p.Category).ToListAsync();
            LatestProducts = _context.Products.OrderByDescending(p => p.Id).Take(6);
            TopSellingProducts = _context.OrderProduct.GroupBy(op => op.ProductFK).Take(6).Select(e => new { Product = _context.Products.Where(p => p.Id == e.Key).FirstOrDefault(), Count = e.Count() }).ToDictionary(e => e.Product, e => e.Count);
            Categories = await _context.ProductCategories.ToListAsync();
        }
    }
}

