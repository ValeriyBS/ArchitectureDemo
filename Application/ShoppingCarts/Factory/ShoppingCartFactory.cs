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
        private readonly IGetShoppingCartItems _getShoppingCartItems;

        public ShoppingCartFactory(IGetShoppingCartItems getShoppingCartItems)
        {
            _getShoppingCartItems = getShoppingCartItems;
        }
        public ShoppingCart Create(string cartId)
        {
            var shoppingCart = new ShoppingCart(cartId)
            {
                ShoppingCartItems = _getShoppingCartItems.Execute(cartId)
            };
            return shoppingCart;
        }
    }
}
