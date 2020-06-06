using System;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.ShoppingCartItems;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;

namespace Persistence.ShoppingCartItems
{
    public class ShoppingCartItemRepository : Repository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public ShoppingCartItemRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public override IQueryable<ShoppingCartItem> GetAll()
        {
            return base.GetAll().Include(s => s.ShopItem);
        }

        public override void Add(ShoppingCartItem shoppingCartItem)
        {
            if (shoppingCartItem?.ShopItem is null) throw new ArgumentNullException(nameof(shoppingCartItem.ShopItem));
            if (shoppingCartItem?.ShoppingCartId is null) throw new ArgumentNullException(nameof(shoppingCartItem.ShoppingCartId));

            var shopItem = _databaseContext.ShopItems.Find(shoppingCartItem.ShopItemId);

            if (shopItem is null) throw new ArgumentException("Shop Item not found with ShopItemId");

            var shoppingCartItemToAdd = _databaseContext.ShoppingCartItems
                .SingleOrDefault(i =>
                    i.ShoppingCartId == shoppingCartItem.ShoppingCartId &&
                    i.ShopItemId == shopItem.Id);

            if (shoppingCartItemToAdd is null)
            {
                base.Add(new ShoppingCartItem
                {
                    ShopItem = shopItem,
                    ShopItemId = shopItem.Id,
                    Amount = 1,
                    ShoppingCartId = shoppingCartItem.ShoppingCartId
                });
            }
            else
            {
                shoppingCartItemToAdd.Amount++;
                _databaseContext.ShoppingCartItems.Update(shoppingCartItemToAdd);
            }

            _databaseContext.Save();
        }

        public override void Remove(ShoppingCartItem shoppingCartItem)
        {
            if (shoppingCartItem is null) throw new ArgumentNullException(nameof(shoppingCartItem));
            var shopItem = _databaseContext.ShopItems.Find(shoppingCartItem.ShopItemId);

            var shoppingCartItemToRemove = _databaseContext.ShoppingCartItems
                .SingleOrDefault(i =>
                    i.ShoppingCartId == shoppingCartItem.ShoppingCartId &&
                    i.ShopItemId == shopItem.Id);

            if (shoppingCartItemToRemove is null) return; 

            if (shoppingCartItemToRemove.Amount <= 1)
            {
                _databaseContext.ShoppingCartItems.Remove(shoppingCartItemToRemove);
            }
            else
            {
                shoppingCartItemToRemove.Amount--;
                _databaseContext.ShoppingCartItems.Update(shoppingCartItemToRemove);
            }

            _databaseContext.Save();
        }
    }
}