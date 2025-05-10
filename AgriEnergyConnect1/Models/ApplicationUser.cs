using Microsoft.AspNetCore.Identity;

namespace AgriEnergyConnect1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; } // "Farmer" or "Employee"
    }
} 