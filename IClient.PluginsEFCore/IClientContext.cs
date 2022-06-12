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

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { InventoryId = 1, Inventoryname = "Процессор", Price = 1000, Quantity = 10 },
                new Inventory { InventoryId = 2, Inventoryname = "Корпус", Price = 20, Quantity = 10},
                new Inventory { InventoryId = 3, Inventoryname = "Блок питания", Price = 100,Quantity = 4 },
                new Inventory { InventoryId = 4, Inventoryname = "HDD", Price = 70, Quantity = 10 },
                new Inventory { InventoryId = 5, Inventoryname = "SSD", Price = 100, Quantity = 10 },
                new Inventory { InventoryId = 6, Inventoryname = "Видеокарта", Price = 300, Quantity = 10 },
                new Inventory { InventoryId = 7, Inventoryname = "Материнская плата", Price = 200, Quantity = 10 },
                new Inventory { InventoryId = 8, Inventoryname = "Оперативная память", Price = 50, Quantity = 10 }
            );

            modelBuilder.Entity<ProductInventory>().HasData(
                new ProductInventory { ProductId = 1, InventoryId = 1, InventoryQuantity = 1},
                new ProductInventory { ProductId = 1, InventoryId = 2, InventoryQuantity = 1 }, 
                new ProductInventory { ProductId = 1, InventoryId = 3, InventoryQuantity = 1 }, 
                new ProductInventory { ProductId = 1, InventoryId = 4, InventoryQuantity = 1 },
                new ProductInventory { ProductId = 1, InventoryId = 5, InventoryQuantity = 1}, 
                new ProductInventory { ProductId = 1, InventoryId = 6, InventoryQuantity = 1 }, 
                new ProductInventory { ProductId = 1, InventoryId = 7, InventoryQuantity = 1 }, 
                new ProductInventory { ProductId = 1, InventoryId = 8, InventoryQuantity = 1 }
            );

            modelBuilder.Entity<ProductInventory>().HasData(
                new ProductInventory { ProductId = 2, InventoryId = 1, InventoryQuantity = 1 },
                new ProductInventory { ProductId = 2, InventoryId = 2, InventoryQuantity = 1 }, 
                new ProductInventory { ProductId = 2, InventoryId = 3, InventoryQuantity = 4 }, 
                new ProductInventory { ProductId = 2, InventoryId = 4, InventoryQuantity = 5 }, 
                new ProductInventory { ProductId = 2, InventoryId = 5, InventoryQuantity = 1 }, 
                new ProductInventory { ProductId = 2, InventoryId = 6, InventoryQuantity = 1 },
                new ProductInventory { ProductId = 2, InventoryId = 7, InventoryQuantity = 1 },
                new ProductInventory { ProductId = 2, InventoryId = 8, InventoryQuantity = 4 }
            );
        }
}