using Smart_Inventory_Management_System.Data.Enum;
using Smart_Inventory_Management_System.DTOs.OrderItem;
using Smart_Inventory_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Smart_Inventory_Management_System.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public string UserId { get; set; }

        public IEnumerable<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    }
    public static class OrderDateValidator
    {
        public static ValidationResult ValidateNotInPast(DateOnly orderDate, ValidationContext context)
        {
            if (orderDate < DateOnly.FromDateTime(DateTime.Today))
            {
                return new ValidationResult("Order date cannot be in the past.");
            }

            return ValidationResult.Success;
        }
    }


}

