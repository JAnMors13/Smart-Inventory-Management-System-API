namespace Smart_Inventory_Management_System.DTOs.OrderItem
{
    public class OrderItemDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }


}
