using System;
using System.Linq;
using Domain.Categories;
using Domain.Common;
using Domain.Customers;
using Domain.OrderDetails;
using Domain.Orders;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Shared
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<ShopItem> ShopItems { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

        public new DbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }

        public void Save()
        {
            SaveChanges();
        }

        //private ILoggerFactory GetLoggerFactory()
        //{
        //    IServiceCollection serviceCollection = new ServiceCollection();
        //    serviceCollection.AddLogging(builder =>
        //        builder.AddConsole()
        //            .AddFilter(DbLoggerCategory.Database.Command.Name,
        //                LogLevel.Information));
        //    return serviceCollection.BuildServiceProvider()
        //        .GetService<ILoggerFactory>();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .Build();

            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category
                {Id = 1, Name = "Men", Description = "Fancy items for men"});
            modelBuilder.Entity<Category>().HasData(new Category
                {Id = 2, Name = "Women", Description = "Fancy items for Women"});
            modelBuilder.Entity<Category>().HasData(new Category
                {Id = 3, Name = "Kids", Description = "Fancy items for kids"});


            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 1,
                CategoryId = 1,
                Name = "Slim Fit Vest",
                ShortDescription = "2020 New Arrival Vests For Men Slim Fit",
                LongDescription = "2020 New Arrival Vests For Men Slim Fit Men Suit Vest Male Waistcoat Casual Sleeveless Formal Business Jacket",
                Price = 5.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/H662e9d9e19444568b60240728509da48Z/2020-New-Arrival-Dress-Vests-For-Men-Slim-Fit-Mens-Suit-Vest-Male-Waistcoat-Gilet-Homme.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/HTB1xsf6b8RRMKJjSZPhq6AZoVXae/2020-New-Arrival-Dress-Vests-For-Men-Slim-Fit-Mens-Suit-Vest-Male-Waistcoat-Gilet-Homme.jpg_640x640.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 2,
                CategoryId = 1,
                Name = "Business Blazer",
                ShortDescription = "2020 Business Blazer Vest Pants",
                LongDescription = "2020 Business Blazer Vest Pants Suit Sets Men Autumn Fashion Solid Slim Wedding Set Vintage Classic Blazers Male",
                Price = 28.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/Hce2dbb8cb8ea4cfd8aa1a9acd155e277z/Men-s-3-Pieces-Black-Elegant-Suits-With-Pants-Vest-Jacket-Slim-Fit-Single-Button-Party.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/H7591aeca8efd457dbdadbf5097fe8e6aE/DIHOPE-2020-Business-Blazer-Vest-Pants-Suit-Sets-Men-Autumn-Fashion-Solid-Slim-Wedding-Set-Vintage.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 3,
                CategoryId = 1,
                Name = "Branded Blazer",
                ShortDescription = "Brand Clothing Men Blazer Fashion",
                LongDescription = "Brand Clothing Men Blazer Fashion Cotton Suit Blazer Slim Fit Masculine Blazer Casual Solid Color Male Suits Jacket",
                Price = 28.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/HTB1QJaIXyrxK1RkHFCcq6AQCVXae/Brand-Clothing-Men-Blazer-Fashion-Cotton-Suit-Blazer-Slim-Fit-Masculine-Blazer-Casual-Solid-Colr-Male.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/HTB1QJaIXyrxK1RkHFCcq6AQCVXae/Brand-Clothing-Men-Blazer-Fashion-Cotton-Suit-Blazer-Slim-Fit-Masculine-Blazer-Casual-Solid-Colr-Male.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 4,
                CategoryId = 1,
                Name = "Burgundy Suit",
                ShortDescription = "New Burgundy Men Suit",
                LongDescription = "New Burgundy Men Suit 2 Pieces Double-breasted Notch Lapel Flat Casual Tuxedos For Wedding(Blazer+Pants)",
                Price = 99.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/Had53cc1a13614e03bfdbd7b227b6ac8fP/New-Burgundy-Men-s-Suit-2-Pieces-Double-breasted-Notch-Lapel-Flat-Casual-Tuxedos-For-Wedding.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/Had53cc1a13614e03bfdbd7b227b6ac8fP/New-Burgundy-Men-s-Suit-2-Pieces-Double-breasted-Notch-Lapel-Flat-Casual-Tuxedos-For-Wedding.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 5,
                CategoryId = 2,
                Name = "Plaid Blazer",
                ShortDescription = "Business Female Blazer Coat",
                LongDescription = "Fashion Autumn Women Plaid Blazers and Jackets Work Office Lady Suit Slim Double Breasted Business Female Blazer Coat Traveler",
                Price = 89.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/H72de7ea354694613b7e64222eede474bm/Fashion-Autumn-Women-Plaid-Blazers-and-Jackets-Work-Office-Lady-Suit-Slim-Double-Breasted-Business-Female.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/H72de7ea354694613b7e64222eede474bm/Fashion-Autumn-Women-Plaid-Blazers-and-Jackets-Work-Office-Lady-Suit-Slim-Double-Breasted-Business-Female.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 6,
                CategoryId = 2,
                Name = "Women Suit",
                ShortDescription = "Blazer Women Suit Jackets Long",
                LongDescription = "Blazer Women Suit Jackets Long Solid Coats Office Ladies Turn Down Collar Jackets Casual Female Outerwear Suit Blazer",
                Price = 75.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/Hfa5b40a7a5364b6e87aa50e066e84e65h/Blazer-Womens-Suit-Jackets-Long-Solid-Coats-Office-Ladies-Turn-Down-Collar-Jackets-Casual-Female-Outerwear.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/Hfa5b40a7a5364b6e87aa50e066e84e65h/Blazer-Womens-Suit-Jackets-Long-Solid-Coats-Office-Ladies-Turn-Down-Collar-Jackets-Casual-Female-Outerwear.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 7,
                CategoryId = 2,
                Name = "Floral Blazer",
                ShortDescription = "Women Floral Print Blazer",
                LongDescription = "Women Floral Print Long Sleeve Blazer 2019 Spring Lightweight Casual Office Lapel Turn Down Collar Slim Jacket Outwear",
                Price = 49.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/HTB1Lq8_QOrpK1RjSZFhq6xSdXXan/Women-Floral-Print-Long-Sleeve-Blazer-2019-Spring-Lightweight-Casual-Office-Lapel-Turn-Down-Collar-Slim.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/HTB1Lq8_QOrpK1RjSZFhq6xSdXXan/Women-Floral-Print-Long-Sleeve-Blazer-2019-Spring-Lightweight-Casual-Office-Lapel-Turn-Down-Collar-Slim.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 8,
                CategoryId = 2,
                Name = "Autumn Blazers",
                ShortDescription = "Fashion Autumn Blazers Jackets",
                LongDescription = "Fashion Autumn Blazers Jackets Women Long Suit Jacket Black Long Sleeve Slim Fit Button blazers Jackets Outerwear",
                Price = 45.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/H6ce15c9de16b4d5f9fdff8ac269bc97fy/Fashion-Autumn-Blazers-Jackets-Women-Long-Suit-Jacket-Black-Long-Sleeve-Slim-Fit-Button-blazers-Jackets.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/H6ce15c9de16b4d5f9fdff8ac269bc97fy/Fashion-Autumn-Blazers-Jackets-Women-Long-Suit-Jacket-Black-Long-Sleeve-Slim-Fit-Button-blazers-Jackets.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 9,
                CategoryId = 3,
                Name = "Wedding Suits",
                ShortDescription = "Boys Wedding Suits Kids",
                LongDescription = "Boys Wedding Suits Kids Clothes Toddler Formal Kids Suit Children Wear Blouse Overalls Tie 3pcs Sets Boys Outfit Baby Clothes",
                Price = 60.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/Hdd06c9d610964fad92e26c15622fde28I/Boys-Wedding-Suits-Kids-Clothes-Toddler-Formal-Kids-Suit-Children-S-Wear-Blouse-Overalls-Tie-3pcs.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/Hdd06c9d610964fad92e26c15622fde28I/Boys-Wedding-Suits-Kids-Clothes-Toddler-Formal-Kids-Suit-Children-S-Wear-Blouse-Overalls-Tie-3pcs.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 10,
                CategoryId = 3,
                Name = "Kids Blazer",
                ShortDescription = "Kids Suits Blazers 2019",
                LongDescription = "Kids Suits Blazers 2019 Autumn Baby Boys Shirt Overalls Coat Tie Boys Suit for Wedding Formal Party Wear Cotton Children Clothes",
                Price = 65.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/HTB17xFhbBCw3KVjSZFuq6AAOpXab/Kids-Suits-Blazers-2019-Autumn-Baby-Boys-Shirt-Overalls-Coat-Tie-Boys-Suit-for-Wedding-Formal.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/HTB17xFhbBCw3KVjSZFuq6AAOpXab/Kids-Suits-Blazers-2019-Autumn-Baby-Boys-Shirt-Overalls-Coat-Tie-Boys-Suit-for-Wedding-Formal.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 11,
                CategoryId = 3,
                Name = "Baby Costume",
                ShortDescription = "Suits for Baby Boy Costume",
                LongDescription = "Suits for Baby Boy Costume Cotton Boys Suits Single Breasted Kids Blazers Boys Suits Set Formal Wedding Wear Children Clothing",
                Price = 65.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/HTB1yIZfdBKw3KVjSZFOq6yrDVXam/Suits-for-Baby-Boy-Costume-Cotton-Boys-Suits-Single-Breasted-Kids-Blazers-Boys-Suits-Set-Formal.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/HTB1yIZfdBKw3KVjSZFOq6yrDVXam/Suits-for-Baby-Boy-Costume-Cotton-Boys-Suits-Single-Breasted-Kids-Blazers-Boys-Suits-Set-Formal.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new
            {
                Id = 12,
                CategoryId = 3,
                Name = "Fashion Blazer",
                ShortDescription = "Boys Fashion Blazer Suit",
                LongDescription = "Boys Fashion Blazer Suit Jacket Flower Boys Clothes Kids Boys Piano Performance Clothes Casual Children Suits Gentleman Sets",
                Price = 65.99m,
                ImageThumbnailUrl = "https://ae01.alicdn.com/kf/H5c00774f0b1b45d6941e69e6134e45303/Boys-Fashion-Blazer-Suit-Jacket-Flower-Boys-Clothes-Kids-Boys-Piano-Performance-Clothes-Casual-Children-s.jpg_220x220xz.jpg_.webp",
                ImageUrl = "https://ae01.alicdn.com/kf/H5c00774f0b1b45d6941e69e6134e45303/Boys-Fashion-Blazer-Suit-Jacket-Flower-Boys-Clothes-Kids-Boys-Piano-Performance-Clothes-Casual-Children-s.jpg",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("Created").HasDefaultValue(DateTime.UtcNow);
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified")
                    .HasDefaultValue(DateTime.UtcNow);
            }
        }


        public override int SaveChanges()
        {
            var timestamp = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Property("LastModified").CurrentValue = timestamp;

                if (entry.State == EntityState.Modified) entry.Property("Created").CurrentValue = timestamp;
            }

            return base.SaveChanges();
        }
    }
}