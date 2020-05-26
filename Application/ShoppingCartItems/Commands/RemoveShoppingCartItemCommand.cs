using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.Persistence;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Commands
{
    public class RemoveShoppingCartItemCommand : IRemoveShoppingCartItemCommand
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public RemoveShoppingCartItemCommand(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }
        public void Execute(int shopItemId, string sessionId)
        {
            _shoppingCartItemRepository.Remove(new ShoppingCartItem()
            {
                ShopItemId = shopItemId,
                ShoppingCartId = sessionId
            });
        }
    }
}
