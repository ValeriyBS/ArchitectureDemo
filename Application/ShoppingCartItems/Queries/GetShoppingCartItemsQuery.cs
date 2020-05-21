using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces.Persistence;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Queries
{
    public class GetShoppingCartItemsQuery : IGetShoppingCartItemsQuery
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public GetShoppingCartItemsQuery(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public List<ShoppingCartItem> Execute(string cartId)
        {
            return _shoppingCartItemRepository
                .GetAll()
                .Where(i => i.ShoppingCartId == cartId).ToList();
        }
    }
}
