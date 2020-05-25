using System.Collections.Generic;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Queries
{
    public interface IGetShoppingCartItemsListQuery
    {
        List<ShoppingCartItem> Execute(string cartId);
    }
}