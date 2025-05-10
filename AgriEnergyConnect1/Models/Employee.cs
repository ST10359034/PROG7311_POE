using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Department { get; set; }
    }
} 