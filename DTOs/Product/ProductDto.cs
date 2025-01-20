using Smart_Inventory_Management_System.DTOs.OrderItem;

namespace Smart_Inventory_Management_System.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string SKU { get; set; } = string.Empty; // Stock Keeping Unit for tracking the product in inventory.
        public int CategoryId { get; set; }

        public IEnumerable<OrderItemDto> OrderItems { get; set; } 
    }
}
