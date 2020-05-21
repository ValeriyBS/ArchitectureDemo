using System.Collections.Generic;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Queries
{
    public interface IGetShoppingCartItemsQuery
    {
        List<ShoppingCartItem> Execute(string cartId);
    }
}