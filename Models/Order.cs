using Smart_Inventory_Management_System.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Inventory_Management_System.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }

        public AppUser User { get; set; } // Many-to-One relationship ni siya sa User.cs
        public ICollection<OrderItem> OrderItems { get; set; } // Many-to-Many relationship ni siya sa OrderItem.cs
    }
 
}