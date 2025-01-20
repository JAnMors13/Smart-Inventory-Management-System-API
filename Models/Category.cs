namespace Smart_Inventory_Management_System.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public ICollection<Product> Products { get; set; } // One-to-Many relationship ni siya sa Product.cs
    }
}