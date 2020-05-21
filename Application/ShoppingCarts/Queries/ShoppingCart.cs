using System.Collections.Generic;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCarts.Queries
{
    public class ShoppingCart
    {

        public ShoppingCart(string uniqueCartId)
        {
            UniqueCartId = uniqueCartId;
        }

        public string UniqueCartId { get; } 
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    }
}
