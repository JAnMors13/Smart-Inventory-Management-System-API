using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Smart_Inventory_Management_System.Data;
using Smart_Inventory_Management_System.DTOs.Product;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SIMSDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(SIMSDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                _logger.LogInformation("Adding a new Product.");
                await _context.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Product with name {ProductName}.", product.Name);
                throw new Exception("An error occurred while creating the Product.", ex);
            }
        }

        public async Task<Product?> DeleteProductAsync(int id)
        {
            try
            {
                var productModel = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (productModel == null)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found.", id);
                    return null;
                }

                _context.Products.Remove(productModel);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Product with ID {ProductId} was successfully deleted.", id);
                return productModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the Product with ID {ProductId}.", id);
                throw new Exception("An error occurred while deleting the Product", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _context.Products.Include(p => p.OrderItems).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all Products.");
                throw new Exception("An error occurred while fetching the Products", ex);
            }
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            try
            {
                return await _context.Products.Include(p => p.OrderItems).FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the Product with ID {ProductId}.", id);
                throw new Exception($"An error occurred while fetching the Product with ID {id}", ex);
            }
        }

        public Task<bool> ProductExistAsync(int productId)
        {
            try
            {
                return _context.Orders.AnyAsync(o => o.Id == productId);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while checking if the Product exists", ex);
            }
        }

        public async Task<Product?> UpdateProductAsync(int id, UpdateProductRequestDto updateDto)
        {
            try
            {
                var productExists = await _context.Products.FindAsync(id);
                if (productExists == null)
                {
                    _logger.LogWarning("Product with ID {ProductId} not found for update.", id);
                    return null;
                }

                productExists.Name = updateDto.Name;
                productExists.Description = updateDto.Description;
                productExists.Price = updateDto.Price;
                productExists.Quantity = updateDto.Quantity;
                productExists.SKU = updateDto.SKU;
                productExists.CategoryId = updateDto.CategoryId;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Product with ID {ProductId} was successfully updated.", id);
                return productExists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the Product with ID {ProductId}.", id);
                throw new Exception("An error occurred while updating the Product", ex);
            }
        }
    }
}
