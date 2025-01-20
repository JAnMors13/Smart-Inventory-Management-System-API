using Smart_Inventory_Management_System.DTOs.User;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Interface
{
    public interface IUserRepository
    {
        Task<UserProfile> GetUserAsync(string Username);
        Task<UserProfile> AddUserAsync(UserProfile user);
        Task<UserProfile?> UpdateUserAsync(int id, UpdateUserProfileRequestDto userDto);
        Task<bool> UserExistsAsync(int UserId);
    }
}
