using Microsoft.EntityFrameworkCore;

namespace Smart_Inventory_Management_System.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        public ICollection<Order> Orders { get; set; } // One-to-Many relationship ni siya sa Order.cs


        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }
    }

    public enum UserRole
    {
        Admin = 1,
        User = 2,
        Manager = 3,
        Employee = 4
    }
}
