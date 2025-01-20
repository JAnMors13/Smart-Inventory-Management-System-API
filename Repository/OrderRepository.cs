using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Smart_Inventory_Management_System.Data;
using Smart_Inventory_Management_System.DTOs.Order;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SIMSDbContext _context;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(SIMSDbContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            try
            {
                _logger.LogInformation("Adding a new order.");
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Order added successfully with ID: {OrderId}", order.Id);
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new order.");
                throw new Exception("An error occurred while creating the Order", ex);
            }
        }

        public async Task<Order?> DeleteOrderAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting order with ID: {OrderId}", id);
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
                if (order == null)
                {
                    _logger.LogWarning("Order with ID: {OrderId} not found.", id);
                    return null;
                }

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Order with ID: {OrderId} deleted successfully.", id);
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting order with ID: {OrderId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetOrderAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all orders.");
                var orders = await _context.Orders.Include(o => o.OrderItems).ThenInclude(o => o.Product).ToListAsync();
                _logger.LogInformation("Fetched {Count} orders.", orders.Count);
                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching orders.");
                throw;
            }
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching order with ID: {OrderId}", id);
                var order = await _context.Orders.Include(o => o.OrderItems).ThenInclude(o => o.Product).FirstOrDefaultAsync(o => o.Id == id);

                if (order == null)
                {
                    _logger.LogWarning("Order with ID: {OrderId} not found.", id);
                }

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching order with ID: {OrderId}", id);
                throw;
            }
        }

        public Task<bool> OrderExistAsync(int orderId)
        {
            try
            {
                return _context.Orders.AnyAsync(o => o.Id == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while checking if the Order exists", ex);
            }
        }

        public async Task<Order?> UpdateOrderAsync(int id, UpdateOrderRequestDto updateDto)
        {
            try
            {
                _logger.LogInformation("Updating order with ID: {OrderId}", id);
                var existingOrder = await _context.Orders.FindAsync(id);
                if (existingOrder == null)
                {
                    _logger.LogWarning("Order with ID: {OrderId} not found.", id);
                    return null;
                }

                if (updateDto.OrderDate.HasValue)
                {
                    existingOrder.OrderDate = updateDto.OrderDate.Value;
                }

                if (updateDto.Status.HasValue)
                {
                    existingOrder.Status = updateDto.Status.Value;
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Order with ID: {OrderId} updated successfully.", id);

                return existingOrder;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating order with ID: {OrderId}", id);
                throw;
            }
        }
    }
}
