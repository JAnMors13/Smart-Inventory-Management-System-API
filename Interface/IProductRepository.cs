using Smart_Inventory_Management_System.DTOs.Product;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, UpdateProductRequestDto updateDto);
        Task<Product?> DeleteProductAsync(int id);
        Task<bool> ProductExistAsync(int productId);
    }
}
