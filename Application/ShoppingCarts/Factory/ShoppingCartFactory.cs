using System;
using System.Collections.Generic;
using System.Linq;
using Application.ShoppingCartItems.Queries;
using Application.ShoppingCarts.Queries;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCarts.Factory
{
    public class ShoppingCartFactory
    {
        private readonly IGetShoppingCartItemsQuery _getShoppingCartItemsQuery;

        public ShoppingCartFactory(IGetShoppingCartItemsQuery getShoppingCartItemsQuery)
        {
            _getShoppingCartItemsQuery = getShoppingCartItemsQuery;
        }
        public ShoppingCart Create(string cartId)
        {
            var shoppingCart = new ShoppingCart(cartId)
            {
                ShoppingCartItems = _getShoppingCartItemsQuery.Execute(cartId)
            };
            return shoppingCart;
        }
    }
}
