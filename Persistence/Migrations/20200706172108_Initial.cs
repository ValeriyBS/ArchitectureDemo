using System;
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
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 871, DateTimeKind.Utc).AddTicks(6791)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 880, DateTimeKind.Utc).AddTicks(2123))
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
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 880, DateTimeKind.Utc).AddTicks(4146)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 880, DateTimeKind.Utc).AddTicks(5385))
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
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 881, DateTimeKind.Utc).AddTicks(3442)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 881, DateTimeKind.Utc).AddTicks(5169))
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
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 880, DateTimeKind.Utc).AddTicks(9745)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 881, DateTimeKind.Utc).AddTicks(1589))
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
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 881, DateTimeKind.Utc).AddTicks(6550)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 881, DateTimeKind.Utc).AddTicks(7823))
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
                    Created = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 880, DateTimeKind.Utc).AddTicks(6908)),
                    LastModified = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 7, 6, 17, 21, 7, 880, DateTimeKind.Utc).AddTicks(8330))
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
                    { 1, 1, "https://ae01.alicdn.com/kf/H662e9d9e19444568b60240728509da48Z/2020-New-Arrival-Dress-Vests-For-Men-Slim-Fit-Mens-Suit-Vest-Male-Waistcoat-Gilet-Homme.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/HTB1xsf6b8RRMKJjSZPhq6AZoVXae/2020-New-Arrival-Dress-Vests-For-Men-Slim-Fit-Mens-Suit-Vest-Male-Waistcoat-Gilet-Homme.jpg_640x640.jpg", true, "2020 New Arrival Vests For Men Slim Fit Men Suit Vest Male Waistcoat Casual Sleeveless Formal Business Jacket", "Slim Fit Vest", "It is a fine item to have!", 5.99m, "2020 New Arrival Vests For Men Slim Fit" },
                    { 2, 1, "https://ae01.alicdn.com/kf/Hce2dbb8cb8ea4cfd8aa1a9acd155e277z/Men-s-3-Pieces-Black-Elegant-Suits-With-Pants-Vest-Jacket-Slim-Fit-Single-Button-Party.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/H7591aeca8efd457dbdadbf5097fe8e6aE/DIHOPE-2020-Business-Blazer-Vest-Pants-Suit-Sets-Men-Autumn-Fashion-Solid-Slim-Wedding-Set-Vintage.jpg", true, "2020 Business Blazer Vest Pants Suit Sets Men Autumn Fashion Solid Slim Wedding Set Vintage Classic Blazers Male", "Business Blazer", "It is a fine item to have!", 28.99m, "2020 Business Blazer Vest Pants" },
                    { 3, 1, "https://ae01.alicdn.com/kf/HTB1QJaIXyrxK1RkHFCcq6AQCVXae/Brand-Clothing-Men-Blazer-Fashion-Cotton-Suit-Blazer-Slim-Fit-Masculine-Blazer-Casual-Solid-Colr-Male.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/HTB1QJaIXyrxK1RkHFCcq6AQCVXae/Brand-Clothing-Men-Blazer-Fashion-Cotton-Suit-Blazer-Slim-Fit-Masculine-Blazer-Casual-Solid-Colr-Male.jpg", true, "Brand Clothing Men Blazer Fashion Cotton Suit Blazer Slim Fit Masculine Blazer Casual Solid Color Male Suits Jacket", "Branded Blazer", "It is a fine item to have!", 28.99m, "Brand Clothing Men Blazer Fashion" },
                    { 4, 1, "https://ae01.alicdn.com/kf/Had53cc1a13614e03bfdbd7b227b6ac8fP/New-Burgundy-Men-s-Suit-2-Pieces-Double-breasted-Notch-Lapel-Flat-Casual-Tuxedos-For-Wedding.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/Had53cc1a13614e03bfdbd7b227b6ac8fP/New-Burgundy-Men-s-Suit-2-Pieces-Double-breasted-Notch-Lapel-Flat-Casual-Tuxedos-For-Wedding.jpg", true, "New Burgundy Men Suit 2 Pieces Double-breasted Notch Lapel Flat Casual Tuxedos For Wedding(Blazer+Pants)", "Burgundy Suit", "It is a fine item to have!", 99.99m, "New Burgundy Men Suit" },
                    { 5, 2, "https://ae01.alicdn.com/kf/H72de7ea354694613b7e64222eede474bm/Fashion-Autumn-Women-Plaid-Blazers-and-Jackets-Work-Office-Lady-Suit-Slim-Double-Breasted-Business-Female.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/H72de7ea354694613b7e64222eede474bm/Fashion-Autumn-Women-Plaid-Blazers-and-Jackets-Work-Office-Lady-Suit-Slim-Double-Breasted-Business-Female.jpg", true, "Fashion Autumn Women Plaid Blazers and Jackets Work Office Lady Suit Slim Double Breasted Business Female Blazer Coat Traveler", "Plaid Blazer", "It is a fine item to have!", 89.99m, "Business Female Blazer Coat" },
                    { 6, 2, "https://ae01.alicdn.com/kf/Hfa5b40a7a5364b6e87aa50e066e84e65h/Blazer-Womens-Suit-Jackets-Long-Solid-Coats-Office-Ladies-Turn-Down-Collar-Jackets-Casual-Female-Outerwear.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/Hfa5b40a7a5364b6e87aa50e066e84e65h/Blazer-Womens-Suit-Jackets-Long-Solid-Coats-Office-Ladies-Turn-Down-Collar-Jackets-Casual-Female-Outerwear.jpg", true, "Blazer Women Suit Jackets Long Solid Coats Office Ladies Turn Down Collar Jackets Casual Female Outerwear Suit Blazer", "Women Suit", "It is a fine item to have!", 75.99m, "Blazer Women Suit Jackets Long" },
                    { 7, 2, "https://ae01.alicdn.com/kf/HTB1Lq8_QOrpK1RjSZFhq6xSdXXan/Women-Floral-Print-Long-Sleeve-Blazer-2019-Spring-Lightweight-Casual-Office-Lapel-Turn-Down-Collar-Slim.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/HTB1Lq8_QOrpK1RjSZFhq6xSdXXan/Women-Floral-Print-Long-Sleeve-Blazer-2019-Spring-Lightweight-Casual-Office-Lapel-Turn-Down-Collar-Slim.jpg", true, "Women Floral Print Long Sleeve Blazer 2019 Spring Lightweight Casual Office Lapel Turn Down Collar Slim Jacket Outwear", "Floral Blazer", "It is a fine item to have!", 49.99m, "Women Floral Print Blazer" },
                    { 8, 2, "https://ae01.alicdn.com/kf/H6ce15c9de16b4d5f9fdff8ac269bc97fy/Fashion-Autumn-Blazers-Jackets-Women-Long-Suit-Jacket-Black-Long-Sleeve-Slim-Fit-Button-blazers-Jackets.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/H6ce15c9de16b4d5f9fdff8ac269bc97fy/Fashion-Autumn-Blazers-Jackets-Women-Long-Suit-Jacket-Black-Long-Sleeve-Slim-Fit-Button-blazers-Jackets.jpg", true, "Fashion Autumn Blazers Jackets Women Long Suit Jacket Black Long Sleeve Slim Fit Button blazers Jackets Outerwear", "Autumn Blazers", "It is a fine item to have!", 45.99m, "Fashion Autumn Blazers Jackets" },
                    { 9, 3, "https://ae01.alicdn.com/kf/Hdd06c9d610964fad92e26c15622fde28I/Boys-Wedding-Suits-Kids-Clothes-Toddler-Formal-Kids-Suit-Children-S-Wear-Blouse-Overalls-Tie-3pcs.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/Hdd06c9d610964fad92e26c15622fde28I/Boys-Wedding-Suits-Kids-Clothes-Toddler-Formal-Kids-Suit-Children-S-Wear-Blouse-Overalls-Tie-3pcs.jpg", true, "Boys Wedding Suits Kids Clothes Toddler Formal Kids Suit Children Wear Blouse Overalls Tie 3pcs Sets Boys Outfit Baby Clothes", "Wedding Suits", "It is a fine item to have!", 60.99m, "Boys Wedding Suits Kids" },
                    { 10, 3, "https://ae01.alicdn.com/kf/HTB17xFhbBCw3KVjSZFuq6AAOpXab/Kids-Suits-Blazers-2019-Autumn-Baby-Boys-Shirt-Overalls-Coat-Tie-Boys-Suit-for-Wedding-Formal.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/HTB17xFhbBCw3KVjSZFuq6AAOpXab/Kids-Suits-Blazers-2019-Autumn-Baby-Boys-Shirt-Overalls-Coat-Tie-Boys-Suit-for-Wedding-Formal.jpg", true, "Kids Suits Blazers 2019 Autumn Baby Boys Shirt Overalls Coat Tie Boys Suit for Wedding Formal Party Wear Cotton Children Clothes", "Kids Blazer", "It is a fine item to have!", 65.99m, "Kids Suits Blazers 2019" },
                    { 11, 3, "https://ae01.alicdn.com/kf/HTB1yIZfdBKw3KVjSZFOq6yrDVXam/Suits-for-Baby-Boy-Costume-Cotton-Boys-Suits-Single-Breasted-Kids-Blazers-Boys-Suits-Set-Formal.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/HTB1yIZfdBKw3KVjSZFOq6yrDVXam/Suits-for-Baby-Boy-Costume-Cotton-Boys-Suits-Single-Breasted-Kids-Blazers-Boys-Suits-Set-Formal.jpg", true, "Suits for Baby Boy Costume Cotton Boys Suits Single Breasted Kids Blazers Boys Suits Set Formal Wedding Wear Children Clothing", "Baby Costume", "It is a fine item to have!", 65.99m, "Suits for Baby Boy Costume" },
                    { 12, 3, "https://ae01.alicdn.com/kf/H5c00774f0b1b45d6941e69e6134e45303/Boys-Fashion-Blazer-Suit-Jacket-Flower-Boys-Clothes-Kids-Boys-Piano-Performance-Clothes-Casual-Children-s.jpg_220x220xz.jpg_.webp", "https://ae01.alicdn.com/kf/H5c00774f0b1b45d6941e69e6134e45303/Boys-Fashion-Blazer-Suit-Jacket-Flower-Boys-Clothes-Kids-Boys-Piano-Performance-Clothes-Casual-Children-s.jpg", true, "Boys Fashion Blazer Suit Jacket Flower Boys Clothes Kids Boys Piano Performance Clothes Casual Children Suits Gentleman Sets", "Fashion Blazer", "It is a fine item to have!", 65.99m, "Boys Fashion Blazer Suit" }
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
