using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces.Persistence;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Queries
{
    public class GetShoppingCartItems : IGetShoppingCartItems
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public GetShoppingCartItems(IShoppingCartItemRepository shoppingCartItemRepository)
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
