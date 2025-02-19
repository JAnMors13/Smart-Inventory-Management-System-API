using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Data
{
    public class SIMSDbContext : IdentityDbContext<AppUser>
    {
        public SIMSDbContext(DbContextOptions<SIMSDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring One-to-Many relationship para sa Products -> Categories
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuring One-to-Many relationship para sa Orders -> AppUser
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            // Configuring Many-to-Many relationship para sa Products -> OrderItems
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            // Seed Roles
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" },
                new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Name = "Employee", NormalizedName = "EMPLOYEE" }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
