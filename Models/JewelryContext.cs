using Microsoft.EntityFrameworkCore;
using Web_project_as.Models;

namespace Web_project_as.Data
{
    public class JewelryContext : DbContext
    {
        public JewelryContext(DbContextOptions<JewelryContext> options)
            : base(options)  { }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. بذر بيانات المستخدمين (مكتوبة بشكل صحيح تماماً)
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, FullName = "Lina", Email = "lina@gmail.com", Password = "123" },
                new User { UserID = 2, FullName = "Sondos Alqirim", Email = "sondos@gmail.com", Password = "456" },
                new User { UserID = 3, FullName = "Aya Alkirim", Email = "aya@gmail.com", Password = "123" }
            );

            // 2. بذر بيانات المنتجات (تم إضافة الـ ProductID يدوياً هنا لسلامة الهجرة)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, ProductName = "Diamond Engagement Ring", Price = 1200, Quantity = 15 },
                new Product { ProductID = 2, ProductName = "Gold Chain Necklace", Price = 450, Quantity = 10 },
                new Product { ProductID = 3, ProductName = "Silver Charm Bracelet", Price = 150, Quantity = 20 },
                new Product { ProductID = 4, ProductName = "Classic Wedding Band", Price = 600, Quantity = 50 }
            );

            // 3. bذر بيانات الطلبات (تم إضافة الـ OrderId يدوياً، مع الحفاظ على ترابط الـ UserID والـ ProductID)
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderID = 1, UserID = 1, ProductID = 1, Quantity = 3 },
                new Order { OrderID = 2, UserID = 2, ProductID = 1, Quantity = 2 },
                new Order { OrderID = 3, UserID = 3, ProductID = 2, Quantity = 5 }
            );
        }
    }
}
