using Smart_Inventory_Management_System.DTOs.User;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserProfileById(string id);
        Task<bool> UserExistsAsync(string userId);
    }
}
