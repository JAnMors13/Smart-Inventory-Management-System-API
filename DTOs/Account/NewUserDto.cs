using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Smart_Inventory_Management_System.DTOs.Account
{
    public class NewUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }

}
