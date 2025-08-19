using Microsoft.EntityFrameworkCore;
using Foodie.Shared.Models;

namespace Foodie.API.Data;

public class FoodieDbContext : DbContext
{
    public FoodieDbContext(DbContextOptions<FoodieDbContext> options) : base(options) { }

    public DbSet<USERS> Users { get; set; }
    public DbSet<PRODUCT> Products { get; set; }
    public DbSet<ORDER> Orders { get; set; }
    public DbSet<ORDER_ITEMS> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ORDER_ITEMS>().HasKey(oi => new { oi.OrderId, oi.ProductId });

        modelBuilder.Entity<ORDER>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(nameof(ORDER.UserId))
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ORDER_ITEMS>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(nameof(ORDER_ITEMS.OrderId))
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ORDER_ITEMS>()
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(nameof(ORDER_ITEMS.ProductId))
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PRODUCT>().Property(nameof(PRODUCT.Price)).HasPrecision(18, 2);
        modelBuilder.Entity<ORDER>().Property(nameof(ORDER.Total)).HasPrecision(18, 2);
        modelBuilder.Entity<ORDER_ITEMS>().Property(nameof(ORDER_ITEMS.Price)).HasPrecision(18, 2);

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<USERS>().HasData(
            new USERS { Id = 1, Name = "John", LastName = "Doe", IdNo = "JD001" },
            new USERS { Id = 2, Name = "Jane", LastName = "Smith", IdNo = "JS002" },
            new USERS { Id = 3, Name = "Mike", LastName = "Johnson", IdNo = "MJ003" },
            new USERS { Id = 4, Name = "Sarah", LastName = "Williams", IdNo = "SW004" },
            new USERS { Id = 5, Name = "David", LastName = "Brown", IdNo = "DB005" }
        );

        modelBuilder.Entity<PRODUCT>().HasData(
            new PRODUCT { Id = 1, Name = "Margherita Pizza", Price = 12.99m, Category = "Pizza" },
            new PRODUCT { Id = 2, Name = "Pepperoni Pizza", Price = 14.99m, Category = "Pizza" },
            new PRODUCT { Id = 3, Name = "Chicken Burger", Price = 8.99m, Category = "Burger" },
            new PRODUCT { Id = 4, Name = "Beef Burger", Price = 9.99m, Category = "Burger" },
            new PRODUCT { Id = 5, Name = "Caesar Salad", Price = 6.99m, Category = "Salad" },
            new PRODUCT { Id = 6, Name = "Greek Salad", Price = 7.99m, Category = "Salad" },
            new PRODUCT { Id = 7, Name = "French Fries", Price = 3.99m, Category = "Side" },
            new PRODUCT { Id = 8, Name = "Onion Rings", Price = 4.99m, Category = "Side" },
            new PRODUCT { Id = 9, Name = "Chocolate Cake", Price = 5.99m, Category = "Dessert" },
            new PRODUCT { Id = 10, Name = "Ice Cream", Price = 4.99m, Category = "Dessert" }
        );

        modelBuilder.Entity<ORDER>().HasData(
            new ORDER { Id = 1, UserId = 1, Total = 26.97m, Status = "Completed" },
            new ORDER { Id = 2, UserId = 2, Total = 18.97m, Status = "Pending" },
            new ORDER { Id = 3, UserId = 3, Total = 15.98m, Status = "Completed" },
            new ORDER { Id = 4, UserId = 1, Total = 12.99m, Status = "In Progress" },
            new ORDER { Id = 5, UserId = 4, Total = 22.96m, Status = "Pending" }
        );

        modelBuilder.Entity<ORDER_ITEMS>().HasData(
            new ORDER_ITEMS { OrderId = 1, ProductId = 1, Quantity = 1, Price = 12.99m },
            new ORDER_ITEMS { OrderId = 1, ProductId = 7, Quantity = 1, Price = 3.99m },
            new ORDER_ITEMS { OrderId = 1, ProductId = 9, Quantity = 1, Price = 5.99m },
            new ORDER_ITEMS { OrderId = 1, ProductId = 10, Quantity = 1, Price = 4.00m },
            new ORDER_ITEMS { OrderId = 2, ProductId = 3, Quantity = 1, Price = 8.99m },
            new ORDER_ITEMS { OrderId = 2, ProductId = 7, Quantity = 1, Price = 3.99m },
            new ORDER_ITEMS { OrderId = 2, ProductId = 9, Quantity = 1, Price = 5.99m },
            new ORDER_ITEMS { OrderId = 3, ProductId = 5, Quantity = 1, Price = 6.99m },
            new ORDER_ITEMS { OrderId = 3, ProductId = 8, Quantity = 1, Price = 4.99m },
            new ORDER_ITEMS { OrderId = 3, ProductId = 10, Quantity = 1, Price = 4.00m },
            new ORDER_ITEMS { OrderId = 4, ProductId = 2, Quantity = 1, Price = 12.99m },
            new ORDER_ITEMS { OrderId = 5, ProductId = 4, Quantity = 1, Price = 9.99m },
            new ORDER_ITEMS { OrderId = 5, ProductId = 6, Quantity = 1, Price = 7.99m },
            new ORDER_ITEMS { OrderId = 5, ProductId = 8, Quantity = 1, Price = 4.98m }
        );
    }
}
