using Smart_Inventory_Management_System.DTOs.Category;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryRequestDto updateDto);
        Task<Category?> DeleteCategoryByIdAsync(int id);
        Task<bool> CategoryExistsAsync(int categoryId);
    }
}
