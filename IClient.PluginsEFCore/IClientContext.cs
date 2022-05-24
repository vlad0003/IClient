using IClient.BusinessCore;
using Microsoft.EntityFrameworkCore;

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
            new Inventory { InventoryId = 1, Inventoryname = "Engine", Price = 400, Quantity = 2 },
            new Inventory { InventoryId = 2, Inventoryname = "Body", Price = 1500, Quantity = 6 },
            new Inventory { InventoryId = 3, Inventoryname = "Wheel", Price = 21400, Quantity = 9 }
        );
        
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductName = "Car", Price = 22400, Quantity = 20 },
            new Product { ProductId = 2, ProductName = "Electric", Price = 21400, Quantity = 60 },
            new Product { ProductId = 3, ProductName = "GasElectric", Price = 55400, Quantity = 32 }
        );
        
        modelBuilder.Entity<ProductInventory>().HasData(
            new ProductInventory { ProductId = 1, InventoryId = 1, InventoryQuantity = 4},
            new ProductInventory { ProductId = 1, InventoryId = 2, InventoryQuantity = 3 },
            new ProductInventory { ProductId = 1, InventoryId = 3, InventoryQuantity = 4 },
            new ProductInventory { ProductId = 1, InventoryId = 4, InventoryQuantity = 5 } 
        );

        modelBuilder.Entity<ProductInventory>().HasData(
            new ProductInventory { ProductId = 2, InventoryId = 5, InventoryQuantity = 3 },
            new ProductInventory { ProductId = 2, InventoryId = 2, InventoryQuantity = 2 }, 
            new ProductInventory { ProductId = 2, InventoryId = 3, InventoryQuantity = 4 }, 
            new ProductInventory { ProductId = 2, InventoryId = 4, InventoryQuantity = 5 }, 
            new ProductInventory { ProductId = 2, InventoryId = 6, InventoryQuantity = 6 } 
        );
    }
}