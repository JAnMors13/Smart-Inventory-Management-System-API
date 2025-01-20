namespace Smart_Inventory_Management_System.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public int UserId { get; set; }

        public UserProfile User { get; set; } // Many-to-One relationship ni siya sa User.cs
        public ICollection<OrderItem> OrderItems { get; set; } // Many-to-Many relationship ni siya sa OrderItem.cs
    }


    public enum OrderStatus
    {
        Pending = 1,
        Shipped = 2,
        Delivered = 3,
        Cancelled = 4
    }
}