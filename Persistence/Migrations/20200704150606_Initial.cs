﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 871, DateTimeKind.Utc).AddTicks(7094)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(1476))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(2686)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(3354))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    LongDescription = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    ImageThumbnailUrl = table.Column<string>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(7582)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(8442))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    OrderPlaced = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(5614)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(6391))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopItemId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(9197)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(9843))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShopItems_ShopItemId",
                        column: x => x.ShopItemId,
                        principalTable: "ShopItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ShopItemId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(4142)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 4, 15, 6, 5, 877, DateTimeKind.Utc).AddTicks(4863))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ShopItems_ShopItemId",
                        column: x => x.ShopItemId,
                        principalTable: "ShopItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Fancy items for men", "Men" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Fancy items for Women", "Women" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Fancy items for kids", "Kids" });

            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "LongDescription", "Name", "Notes", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, 1, "", "", true, "Very very sleek trousers", "Sleek Trousers", "It is a fine item to have!", 5.99m, "Very Sleek Trousers" },
                    { 2, 1, "", "", true, "Very heavy duty trousers", "Work Trousers", "It is a fine item to have!", 28.99m, "Heavy Duty Trousers" },
                    { 3, 2, "", "", true, "Very very sleek dress", "Sleek Dress", "It is a fine item to have!", 0.99m, "Very Sleek dress" },
                    { 4, 2, "", "", true, "Very heavy duty work dress", "Work Dress", "It is a fine item to have!", 15.99m, "Heavy duty work dress" },
                    { 5, 3, "", "", true, "Very very sleek diapers", "Sleek Diapers", "It is a fine item to have!", 0.99m, "Very sleek diapers" },
                    { 6, 3, "", "", true, "Very heavy duty diapers", "Work diapers", "It is a fine item to have!", 15.99m, "Heavy duty work diapers" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ShopItemId",
                table: "OrderDetails",
                column: "ShopItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_CategoryId",
                table: "ShopItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShopItemId",
                table: "ShoppingCartItems",
                column: "ShopItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShopItems");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}