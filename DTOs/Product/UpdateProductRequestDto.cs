using System.ComponentModel.DataAnnotations;

namespace Smart_Inventory_Management_System.DTOs.Product
{
    public class UpdateProductRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 10000000, ErrorMessage = "Price must be between 0.01 and 10,000,000.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int Quantity { get; set; }

        [MaxLength(50, ErrorMessage = "SKU can't be longer than 50 characters.")]
        public string SKU { get; set; } = string.Empty; 

        public int CategoryId { get; set; }
    }
}
