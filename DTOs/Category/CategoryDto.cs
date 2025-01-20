using Smart_Inventory_Management_System.DTOs.Product;

namespace Smart_Inventory_Management_System.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public IEnumerable<ProductDto> Products { get; set; }
    }
}
