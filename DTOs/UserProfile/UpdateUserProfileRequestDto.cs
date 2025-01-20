using Smart_Inventory_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Smart_Inventory_Management_System.DTOs.User
{
    public class UpdateUserProfileRequestDto
    {
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(50, ErrorMessage = "Username can't be longer than 50 characters.")]
        public string? Username { get; set; }

        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [EnumDataType(typeof(UserRole), ErrorMessage = "Role must be either 'Admin', 'Manager', 'Employee', or 'User'.")]
        public UserRole? Role { get; set; }

    }
}
