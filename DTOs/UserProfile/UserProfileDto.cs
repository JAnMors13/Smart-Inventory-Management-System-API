using Smart_Inventory_Management_System.DTOs.Order;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.DTOs.User
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }

}
