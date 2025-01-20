using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Smart_Inventory_Management_System.Data;
using Smart_Inventory_Management_System.DTOs.User;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<UserProfile> AddUserAsync(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> GetUserAsync(string Username)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile?> UpdateUserAsync(int id, UpdateUserProfileRequestDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsAsync(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
