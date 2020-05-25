using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces.Persistence;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Queries
{
    public class GetShoppingCartItemsListQuery : IGetShoppingCartItemsListQuery
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public GetShoppingCartItemsListQuery(IShoppingCartItemRepository shoppingCartItemRepository)
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
