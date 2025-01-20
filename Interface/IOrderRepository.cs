using Smart_Inventory_Management_System.DTOs.Order;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrderAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order> AddOrderAsync(Order order);
        Task<Order?> UpdateOrderAsync(int id, UpdateOrderRequestDto updateDto);
        Task<Order?> DeleteOrderAsync(int id);
        Task<bool> OrderExistAsync(int orderId);
    }
}
