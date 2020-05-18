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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .Build();

            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Men" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Women" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Kids" });


            modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            {
                Id = 1,
                CategoryId = 1,
                Name = "Sleek Trousers",
                ShortDescription = "Very Sleek Trousers",
                LongDescription = "Very very sleek trousers",
                Price = 5.99m,
                ImageThumbnailUrl = "",
                ImageUrl = "",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            {
                Id = 2,
                CategoryId = 1,
                Name = "Work Trousers",
                ShortDescription = "Heavy Duty Trousers",
                LongDescription = "Very heavy duty trousers",
                Price = 28.99m,
                ImageThumbnailUrl = "",
                ImageUrl = "",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            {
                Id = 3,
                CategoryId = 2,
                Name = "Sleek Dress",
                ShortDescription = "Very Sleek dress",
                LongDescription = "Very very sleek dress",
                Price = 0.99m,
                ImageThumbnailUrl = "",
                ImageUrl = "",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            {
                Id = 4,
                CategoryId = 2,
                Name = "Work Dress",
                ShortDescription = "Heavy duty work dress",
                LongDescription = "Very heavy duty work dress",
                Price = 15.99m,
                ImageThumbnailUrl = "",
                ImageUrl = "",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            {
                Id = 5,
                CategoryId = 3,
                Name = "Sleek Diapers",
                ShortDescription = "Very sleek diapers",
                LongDescription = "Very very sleek diapers",
                Price = 0.99m,
                ImageThumbnailUrl = "",
                ImageUrl = "",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            {
                Id = 6,
                CategoryId = 3,
                Name = "Work diapers",
                ShortDescription = "Heavy duty work diapers",
                LongDescription = "Very heavy duty diapers",
                Price = 15.99m,
                ImageThumbnailUrl = "",
                ImageUrl = "",
                InStock = true,
                Notes = "It is a fine item to have!"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1, FirstName = "Gordon", LastName = "Freeman", Email = "Gordon.Freeman@Gmail.com",
                City = "Washington", Country = "USA", State = "Washington"
            });


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("Created").HasDefaultValue(DateTime.UtcNow);
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified").HasDefaultValue(DateTime.UtcNow);
            }
        }


        public override int SaveChanges()
        {
            var timestamp = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries()
                .Where(e=>e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Property("LastModified").CurrentValue = timestamp;

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Created").CurrentValue = timestamp;
                }
            }
            return base.SaveChanges();
        }
    }
}