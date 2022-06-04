using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IClient.PluginsEFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Inventoryname = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTransactions",
                columns: table => new
                {
                    InventoryTransactionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActivityType = table.Column<int>(type: "integer", nullable: false),
                    InventoryId = table.Column<int>(type: "integer", nullable: false),
                    QuantityBefore = table.Column<int>(type: "integer", nullable: false),
                    QuantityAfter = table.Column<int>(type: "integer", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoneBy = table.Column<string>(type: "text", nullable: false),
                    PONumber = table.Column<string>(type: "text", nullable: true),
                    ProductionNumber = table.Column<string>(type: "text", nullable: true),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransactions", x => x.InventoryTransactionId);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    InventoryId = table.Column<int>(type: "integer", nullable: false),
                    InventoryQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventory", x => new { x.ProductId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_ProductInventory_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTransactions",
                columns: table => new
                {
                    ProductTransactionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActivityType = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    QuantityBefore = table.Column<int>(type: "integer", nullable: false),
                    QuantityAfter = table.Column<int>(type: "integer", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoneBy = table.Column<string>(type: "text", nullable: false),
                    SalesOrderNumber = table.Column<string>(type: "text", nullable: true),
                    ProductionNumber = table.Column<string>(type: "text", nullable: true),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTransactions", x => x.ProductTransactionId);
                    table.ForeignKey(
                        name: "FK_ProductTransactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "Inventoryname", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Процессор", 1000.0, 10 },
                    { 2, "Корпус", 20.0, 10 },
                    { 3, "Блок питания", 100.0, 4 },
                    { 4, "HDD", 70.0, 10 },
                    { 5, "SSD", 100.0, 10 },
                    { 6, "Видеокарта", 300.0, 10 },
                    { 7, "Материнская плата", 200.0, 10 },
                    { 8, "Оперативная память", 50.0, 10 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "IsActive", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, true, 2000.0, "Игровой пк", 5 },
                    { 2, true, 700.0, "Бюджетный пк", 5 }
                });

            migrationBuilder.InsertData(
                table: "ProductInventory",
                columns: new[] { "InventoryId", "ProductId", "InventoryQuantity" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 3, 1, 1 },
                    { 4, 1, 1 },
                    { 5, 1, 1 },
                    { 6, 1, 1 },
                    { 7, 1, 1 },
                    { 8, 1, 1 },
                    { 1, 2, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 4 },
                    { 4, 2, 5 },
                    { 5, 2, 1 },
                    { 6, 2, 1 },
                    { 7, 2, 1 },
                    { 8, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_InventoryId",
                table: "InventoryTransactions",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_InventoryId",
                table: "ProductInventory",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransactions_ProductId",
                table: "ProductTransactions",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryTransactions");

            migrationBuilder.DropTable(
                name: "ProductInventory");

            migrationBuilder.DropTable(
                name: "ProductTransactions");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
