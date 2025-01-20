using System.ComponentModel.DataAnnotations;

namespace Smart_Inventory_Management_System.DTOs.Product
{
    public class CreateProductRequestDto
    {
        [Required(ErrorMessage = "Product name cannot be empty")]
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        
        public int Quantity { get; set; }

        [MaxLength(50, ErrorMessage = "SKU can't be longer than 50 characters.")]
        public string SKU { get; set; } = string.Empty;
    }
}
