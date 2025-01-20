using System.ComponentModel.DataAnnotations;

namespace Smart_Inventory_Management_System.DTOs.OrderItem
{
    public class CreateOrderItemRequestDto
    {
        [Required(ErrorMessage = "Order ID is required.")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Product ID is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
    }
}
