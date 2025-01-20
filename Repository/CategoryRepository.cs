using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Smart_Inventory_Management_System.Data;
using Smart_Inventory_Management_System.DTOs.Category;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SIMSDbContext _context;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(SIMSDbContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Category.");
                throw new Exception("An error occurred while creating the Category.", ex);
            }
        }

        public async Task<Category?> DeleteCategoryByIdAsync(int id)
        {
            try
            {
                var categoryModel = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (categoryModel == null) return null;

                _context.Categories.Remove(categoryModel);
                await _context.SaveChangesAsync();
                return categoryModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the Category with ID {CategoryId}.", id);
                throw new Exception("An error occurred while deleting the Category", ex);
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            try
            {
                return await _context.Categories.Include(c => c.Products).ThenInclude(c => c.OrderItems).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the Categories.");
                throw new Exception("An error occurred while fetching the Categories", ex);
            }
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            try
            {
                return await _context.Categories.Include(c => c.Products).ThenInclude(c => c.OrderItems).FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the Category with ID {CategoryId}.", id);
                throw new Exception($"An error occurred while fetching the Category with ID {id}", ex);
            }
        }

        public async Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryRequestDto updateDto)
        {
            try
            {
                var existingCategory = await _context.Categories.FindAsync(id);
                if (existingCategory == null) return null;

                existingCategory.Name = updateDto.Name;

                await _context.SaveChangesAsync();
                return existingCategory;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the Category with ID {CategoryId}.", id);
                throw new Exception("An error occurred while updating the Category", ex);
            }
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            try
            {
                return await _context.Categories.AnyAsync(c => c.Id == categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while checking if the Category with ID {CategoryId} exists.", categoryId);
                throw new Exception("An error occurred while checking if the Category exists", ex);
            }
        }
    }
}
