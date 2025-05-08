using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;
using System.Linq;
using System.Security.Claims;

namespace AgriEnergyConnect.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var farmer = _context.Farmers.FirstOrDefault(f => f.Email == userEmail);
            var products = _context.Products.Where(p => p.FarmerId == farmer.Id).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var userEmail = User.FindFirstValue(ClaimTypes.Email);
                var farmer = _context.Farmers.FirstOrDefault(f => f.Email == userEmail);
                product.FarmerId = farmer.Id;
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(product);
        }
    }
} 