using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;
using System.Linq;

namespace AgriEnergyConnect.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            var farmers = _context.Farmers.ToList();
            return View(farmers);
        }

        [HttpGet]
        public IActionResult AddFarmer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFarmer(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                _context.Farmers.Add(farmer);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(farmer);
        }

        public IActionResult Products(string category = null)
        {
            var products = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }
            return View(products.ToList());
        }
    }
} 