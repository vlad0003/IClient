using IClient.BusinessCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IClient.PluginsEFCore;

public class IClientContext : DbContext
{
   public IClientContext(DbContextOptions options) : base(options)
        {
        }
   public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<ProductTransaction> ProductTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //build relationships
            modelBuilder.Entity<ProductInventory>()
                .HasKey(pi => new { pi.ProductId, pi.InventoryId });

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductInventories)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Inventory)
                .WithMany(i => i.ProductInventories)
                .HasForeignKey(pi => pi.InventoryId);

            //seeding data
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { InventoryId = 1, Inventoryname = "Gas Engine", Price = 1000, Quantity = 1 },
                new Inventory { InventoryId = 2, Inventoryname = "Body", Price = 400, Quantity = 1},
                new Inventory { InventoryId = 3, Inventoryname = "Wheel", Quantity = 4, Price = 100 },
                new Inventory { InventoryId = 4, Inventoryname = "Seat", Price = 50, Quantity = 5 },
                new Inventory { InventoryId = 5, Inventoryname = "Electric Engine", Price = 8000, Quantity = 2 },
                new Inventory { InventoryId = 6, Inventoryname = "Battery", Price = 400, Quantity = 5 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Gas Car", Price = 20000, Quantity = 1 },
                new Product { ProductId = 2, ProductName = "Electric Car", Price = 15000, Quantity = 1 }
            );

            modelBuilder.Entity<ProductInventory>().HasData(
                new ProductInventory { ProductId = 1, InventoryId = 1, InventoryQuantity = 1}, // engine
                new ProductInventory { ProductId = 1, InventoryId = 2, InventoryQuantity = 1 }, // body
                new ProductInventory { ProductId = 1, InventoryId = 3, InventoryQuantity = 4 }, //4 wheels
                new ProductInventory { ProductId = 1, InventoryId = 4, InventoryQuantity = 5 } //5 seats
            );

            modelBuilder.Entity<ProductInventory>().HasData(
                new ProductInventory { ProductId = 2, InventoryId = 5, InventoryQuantity = 1 }, // engine
                new ProductInventory { ProductId = 2, InventoryId = 2, InventoryQuantity = 1 }, // body
                new ProductInventory { ProductId = 2, InventoryId = 3, InventoryQuantity = 4 }, //4 wheels
                new ProductInventory { ProductId = 2, InventoryId = 4, InventoryQuantity = 5 }, //5 seats
                new ProductInventory { ProductId = 2, InventoryId = 6, InventoryQuantity = 1 } // battery
            );
    }
}