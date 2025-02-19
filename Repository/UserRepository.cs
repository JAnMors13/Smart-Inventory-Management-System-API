using AutoMapper;
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
        private readonly SIMSDbContext _context;
        public UserRepository(SIMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _context.Users.Include(c => c.Orders).ToListAsync();
        }

        public async Task<AppUser> GetUserProfileById(string id)
        {
            return await _context.Users.Include(c => c.Orders).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> UserExistsAsync(string userId)
        {
            return await _context.Users.AnyAsync(u => u.Id == userId);
        }
    }
}
