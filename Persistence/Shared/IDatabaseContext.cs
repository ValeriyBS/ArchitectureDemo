using Domain.Categories;
using Domain.Common;
using Domain.Customers;
using Domain.OrderDetails;
using Domain.Orders;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Shared
{
    public interface IDatabaseContext
    {
        DbSet<ShopItem> ShopItems { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Customer> Customers { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<OrderDetail> OrderDetails { get; set; }

        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        DbSet<T> Set<T>() where T : class, IEntity;

        void Save();
    }
}