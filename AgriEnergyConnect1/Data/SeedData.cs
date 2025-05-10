using System;
using System.Linq;
using AgriEnergyConnect1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AgriEnergyConnect1.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any farmers.
                if (context.Farmers.Any())
                {
                    return;   // DB has been seeded
                }

                var farmer1 = new Farmer { Name = "John Doe", Email = "john@farm.com", Location = "Eastern Cape" };
                var farmer2 = new Farmer { Name = "Mary Smith", Email = "mary@farm.com", Location = "Western Cape" };
                context.Farmers.AddRange(farmer1, farmer2);

                var employee1 = new Employee { Name = "Alice Green", Email = "alice@energy.com", Department = "Solar" };
                var employee2 = new Employee { Name = "Bob Brown", Email = "bob@energy.com", Department = "Wind" };
                context.Employees.AddRange(employee1, employee2);

                context.SaveChanges();

                var product1 = new Product { Name = "Organic Tomatoes", Category = "Vegetables", ProductionDate = DateTime.Now.AddDays(-10), FarmerId = farmer1.Id };
                var product2 = new Product { Name = "Free-range Eggs", Category = "Poultry", ProductionDate = DateTime.Now.AddDays(-5), FarmerId = farmer2.Id };
                var product3 = new Product { Name = "Solar Pump", Category = "Equipment", ProductionDate = DateTime.Now.AddDays(-2), FarmerId = farmer1.Id };
                context.Products.AddRange(product1, product2, product3);

                context.SaveChanges();
            }
        }
    }
} 