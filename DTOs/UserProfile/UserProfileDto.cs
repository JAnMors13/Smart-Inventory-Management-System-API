using Smart_Inventory_Management_System.Data.Enum;
using Smart_Inventory_Management_System.DTOs.Order;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.DTOs.User
{
    public class UserProfileDto
    {
        public string Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; }

        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }


}
