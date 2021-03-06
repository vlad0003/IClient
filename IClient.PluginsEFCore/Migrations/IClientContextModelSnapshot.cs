// <auto-generated />
using System;
using IClient.PluginsEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IClient.PluginsEFCore.Migrations
{
    [DbContext(typeof(IClientContext))]
    partial class IClientContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IClient.BusinessCore.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InventoryId"));

                    b.Property<string>("Inventoryname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            InventoryId = 1,
                            Inventoryname = "Процессор",
                            Price = 1000.0,
                            Quantity = 10
                        },
                        new
                        {
                            InventoryId = 2,
                            Inventoryname = "Корпус",
                            Price = 20.0,
                            Quantity = 10
                        },
                        new
                        {
                            InventoryId = 3,
                            Inventoryname = "Блок питания",
                            Price = 100.0,
                            Quantity = 4
                        },
                        new
                        {
                            InventoryId = 4,
                            Inventoryname = "HDD",
                            Price = 70.0,
                            Quantity = 10
                        },
                        new
                        {
                            InventoryId = 5,
                            Inventoryname = "SSD",
                            Price = 100.0,
                            Quantity = 10
                        },
                        new
                        {
                            InventoryId = 6,
                            Inventoryname = "Видеокарта",
                            Price = 300.0,
                            Quantity = 10
                        },
                        new
                        {
                            InventoryId = 7,
                            Inventoryname = "Материнская плата",
                            Price = 200.0,
                            Quantity = 10
                        },
                        new
                        {
                            InventoryId = 8,
                            Inventoryname = "Оперативная память",
                            Price = 50.0,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("IClient.BusinessCore.InventoryTransaction", b =>
                {
                    b.Property<int>("InventoryTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InventoryTransactionId"));

                    b.Property<int>("ActivityType")
                        .HasColumnType("integer");

                    b.Property<string>("DoneBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("InventoryId")
                        .HasColumnType("integer");

                    b.Property<string>("PONumber")
                        .HasColumnType("text");

                    b.Property<string>("ProductionNumber")
                        .HasColumnType("text");

                    b.Property<int>("QuantityAfter")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityBefore")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("double precision");

                    b.HasKey("InventoryTransactionId");

                    b.HasIndex("InventoryId");

                    b.ToTable("InventoryTransactions");
                });

            modelBuilder.Entity("IClient.BusinessCore.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            IsActive = true,
                            Price = 2000.0,
                            ProductName = "Игровой пк",
                            Quantity = 5
                        },
                        new
                        {
                            ProductId = 2,
                            IsActive = true,
                            Price = 700.0,
                            ProductName = "Бюджетный пк",
                            Quantity = 5
                        });
                });

            modelBuilder.Entity("IClient.BusinessCore.ProductInventory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("InventoryId")
                        .HasColumnType("integer");

                    b.Property<int>("InventoryQuantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "InventoryId");

                    b.HasIndex("InventoryId");

                    b.ToTable("ProductInventory");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            InventoryId = 1,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 1,
                            InventoryId = 2,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 1,
                            InventoryId = 3,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 1,
                            InventoryId = 4,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 1,
                            InventoryId = 5,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 1,
                            InventoryId = 6,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 1,
                            InventoryId = 7,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 1,
                            InventoryId = 8,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 2,
                            InventoryId = 1,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 2,
                            InventoryId = 2,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 2,
                            InventoryId = 3,
                            InventoryQuantity = 4
                        },
                        new
                        {
                            ProductId = 2,
                            InventoryId = 4,
                            InventoryQuantity = 5
                        },
                        new
                        {
                            ProductId = 2,
                            InventoryId = 5,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 2,
                            InventoryId = 6,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 2,
                            InventoryId = 7,
                            InventoryQuantity = 1
                        },
                        new
                        {
                            ProductId = 2,
                            InventoryId = 8,
                            InventoryQuantity = 4
                        });
                });

            modelBuilder.Entity("IClient.BusinessCore.ProductTransaction", b =>
                {
                    b.Property<int>("ProductTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductTransactionId"));

                    b.Property<int>("ActivityType")
                        .HasColumnType("integer");

                    b.Property<string>("DoneBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductionNumber")
                        .HasColumnType("text");

                    b.Property<int>("QuantityAfter")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityBefore")
                        .HasColumnType("integer");

                    b.Property<string>("SalesOrderNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("double precision");

                    b.HasKey("ProductTransactionId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTransactions");
                });

            modelBuilder.Entity("IClient.BusinessCore.InventoryTransaction", b =>
                {
                    b.HasOne("IClient.BusinessCore.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("IClient.BusinessCore.ProductInventory", b =>
                {
                    b.HasOne("IClient.BusinessCore.Inventory", "Inventory")
                        .WithMany("ProductInventories")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IClient.BusinessCore.Product", "Product")
                        .WithMany("ProductInventories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("IClient.BusinessCore.ProductTransaction", b =>
                {
                    b.HasOne("IClient.BusinessCore.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("IClient.BusinessCore.Inventory", b =>
                {
                    b.Navigation("ProductInventories");
                });

            modelBuilder.Entity("IClient.BusinessCore.Product", b =>
                {
                    b.Navigation("ProductInventories");
                });
#pragma warning restore 612, 618
        }
    }
}
