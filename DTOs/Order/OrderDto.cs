using Smart_Inventory_Management_System.DTOs.OrderItem;
using Smart_Inventory_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Smart_Inventory_Management_System.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public int UserId { get; set; }

        public IEnumerable<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    }
    public static class OrderDateValidator
    {
        public static ValidationResult ValidateNotInPast(DateTime orderDate, ValidationContext context)
        {
            if (orderDate < DateTime.Today)
            {
                return new ValidationResult("Order date cannot be in the past.");
            }

            return ValidationResult.Success;
        }
    }

}

