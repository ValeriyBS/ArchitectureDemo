﻿
using Domain.ShoppingCartItems;

namespace Application.Interfaces.Persistence
{
    public interface IShoppingCartItemRepository : IRepository<ShoppingCartItem>
    {
        void Clear(string cartId);
    }
}
