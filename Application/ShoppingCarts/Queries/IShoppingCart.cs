using System.Collections.Generic;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCarts.Queries
{
    public interface IShoppingCart
    {
        string CartId { get; }
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}