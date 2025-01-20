using System.ComponentModel.DataAnnotations;

namespace Smart_Inventory_Management_System.DTOs.Category
{
    public class UpdateCategoryRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
