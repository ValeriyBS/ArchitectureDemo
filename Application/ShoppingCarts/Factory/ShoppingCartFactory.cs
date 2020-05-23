using System;
using System.Collections.Generic;
using System.Linq;
using Application.ShoppingCartItems.Queries;
using Application.ShoppingCarts.Queries;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCarts.Factory
{
    public class ShoppingCartFactory : IShoppingCartFactory
    {
        private readonly IGetShoppingCartItemsQuery _getShoppingCartItemsQuery;

        public ShoppingCartFactory(IGetShoppingCartItemsQuery getShoppingCartItemsQuery)
        {
            _getShoppingCartItemsQuery = getShoppingCartItemsQuery;
        }
        public ShoppingCart Create(string cartId)
        {
            var newCartId = cartId ?? Guid.NewGuid().ToString();
            var shoppingCart = new ShoppingCart(newCartId)
            {
                ShoppingCartItems = _getShoppingCartItemsQuery.Execute(newCartId)
            };
            return shoppingCart;
        }
    }
}
