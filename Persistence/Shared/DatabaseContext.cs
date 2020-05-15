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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    optionsBuilder
        //        .UseSqlServer(configuration.GetConnectionString("MyConnection"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var categoryMen = new Category {Id = 1, Name = "Men"};
            //var categoryWomen = new Category {Id = 2, Name = "Women"};
            //var categoryKids = new Category {Id = 3, Name = "Kids"};

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Men" });
            //modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Women" });
            //modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Kids" });


            modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            {
                Id = 1,
                Name = "Sleek Trousers",
                ShortDescription = "Very Sleek Trousers",
                LongDescription = "Very very sleek trousers",
                Price = 5.99m,
                ImageThumbnailUrl = "",
                InStock = true,
                CategoryId = 1,
                Notes = "It is a fine item to have!"});

            //modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            //    {Id = 2, Category = categoryMen, CategoryId = 1, Name = "Work Trousers", Price = 8.99m});
            //modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            //{
            //    Id = 3, Category = categoryWomen, CategoryId = 2, Name = "Sleek Dress", Price = 15.99m
            //});
            //modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            //    {Id = 4, Category = categoryWomen, CategoryId = 2, Name = "Work Dress", Price = 20.99m});
            //modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            //{
            //    Id = 5, Category = categoryKids, CategoryId = 3, Name = "Sleek Diapers", Price = 10.99m
            //});
            //modelBuilder.Entity<ShopItem>().HasData(new ShopItem
            //    {Id = 6, Category = categoryKids, CategoryId = 3, Name = "Work Diapers", Price = 12.99m});

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1, FirstName = "Gordon", LastName = "Freeman", Email = "Gordon.Freeman@Gmail.com",
                City = "Washington", Country = "USA", State = "Washington"
            });
        }
    }
}