using Microsoft.AspNetCore.Identity;
using Smart_Inventory_Management_System.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Inventory_Management_System.Models
{
    public class AppUser : IdentityUser
    {
        public UserRole Role { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
