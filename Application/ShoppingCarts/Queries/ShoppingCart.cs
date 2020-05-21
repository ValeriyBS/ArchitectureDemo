using System.Collections.Generic;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCarts.Queries
{
    public class ShoppingCart
    {

        public ShoppingCart(string cartId)
        {
            CartId = cartId;
        }

        public string CartId { get; } 
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    }
}
