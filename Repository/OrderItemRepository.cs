using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interface;
using Microsoft.EntityFrameworkCore;
using Smart_Inventory_Management_System.Data;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly SIMSDbContext _context;
        private readonly ILogger<OrderItemRepository> _logger;

        public OrderItemRepository(SIMSDbContext context, ILogger<OrderItemRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OrderItem> CreateAsync(OrderItem orderItem)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == orderItem.ProductId);

            if (product == null)
            {
                _logger.LogWarning($"Product with ID {orderItem.ProductId} not found.");
                throw new KeyNotFoundException("Product not found.");
            }

            if (product.Quantity < orderItem.Quantity)
            {
                _logger.LogWarning($"Insufficient stock for product with ID {orderItem.ProductId}. Available: {product.Quantity}, Requested: {orderItem.Quantity}");
                throw new InvalidOperationException("Insufficient stock.");
            }

            var existingOrderItem = await _context.OrderItems.FirstOrDefaultAsync(oi => oi.OrderId == orderItem.OrderId && oi.ProductId == orderItem.ProductId);

            if (existingOrderItem != null)
            {
                existingOrderItem.Quantity += orderItem.Quantity;
                product.Quantity -= orderItem.Quantity;

                await _context.SaveChangesAsync();
                _logger.LogInformation($"Updated order item for Product {product.Name}, Order ID {orderItem.OrderId}. New Quantity: {existingOrderItem.Quantity}");
                return existingOrderItem;
            }

            product.Quantity -= orderItem.Quantity;

            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Created new order item for Product {product.Name}, Order ID {orderItem.OrderId}. Quantity deducted: {orderItem.Quantity}");

            return orderItem;
        }


        public async Task<OrderItem> DeleteOrderItem(int orderId)
        {
            var orderItem = await _context.OrderItems.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (orderItem == null) return null;
            
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<List<OrderItem>> GetOrderItems(int orderId)
        {
            return await _context.OrderItems
                .Where(o => o.OrderId == orderId)
                .Include(o => o.Product) 
                .ToListAsync();
        }
    }
}
