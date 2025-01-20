using System.ComponentModel.DataAnnotations;

namespace Smart_Inventory_Management_System.DTOs.OrderItem
{
    public class UpdateOrderItemRequestDto
    {
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}
