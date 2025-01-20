using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Smart_Inventory_Management_System.Models;

namespace api.Interface
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetOrderItems(int orderId);
        Task<OrderItem> CreateAsync(OrderItem orderItem);
        Task<OrderItem> DeleteOrderItem(int orderId);
        
    }
}
