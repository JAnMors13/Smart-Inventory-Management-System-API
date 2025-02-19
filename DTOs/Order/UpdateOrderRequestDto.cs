using Smart_Inventory_Management_System.Data.Enum;
using Smart_Inventory_Management_System.DTOs.OrderItem;
using Smart_Inventory_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Smart_Inventory_Management_System.DTOs.Order
{
    public class UpdateOrderRequestDto
    {
        [CustomValidation(typeof(OrderDateValidator), nameof(OrderDateValidator.ValidateNotInPast))]
        [Range(typeof(DateOnly), "01/01/2022", "12/31/2099", ErrorMessage = "Invalid order date range.")]
        public DateOnly? OrderDate { get; set; }

        [EnumDataType(typeof(OrderStatus), ErrorMessage = "Invalid order status.")]
        public OrderStatus? Status { get; set; }
        public string UserId { get; set; }

    }


}
