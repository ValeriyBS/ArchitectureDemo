using System.Collections.Generic;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Queries
{
    public interface IGetShoppingCartItems
    {
        List<ShoppingCartItem> Execute(string cartId);
    }
}