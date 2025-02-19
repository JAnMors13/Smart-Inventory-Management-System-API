using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Inventory_Management_System.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; } 
        public string SKU { get; set; } = string.Empty; // Stock Keeping Unit kai para sa pag-track sa product sa inventory 
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; } // Many-to-One relationship ni siya sa Category.cs
        public ICollection<OrderItem> OrderItems { get; set; } // Many-to-Many relationship ni siya sa OrderItem.cs
    }
}
