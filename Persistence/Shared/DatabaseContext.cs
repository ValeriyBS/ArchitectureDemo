using Domain.Category;
using Domain.Common;
using Domain.ShopItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;

namespace Persistence.Shared
{
    internal class DatabaseContext : DbContext,IDatabaseContext
    {
        public DbSet<ShopItem> ShopItems { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("MyConnection"));
        }

        public new DbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
