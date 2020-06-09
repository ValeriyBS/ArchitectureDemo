using System;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Commands
{
    public class AddShoppingCartItemCommand : IAddShoppingCartItemCommand
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public AddShoppingCartItemCommand(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public void Execute(int shopItemId, string cartId)
        {
            if (string.IsNullOrWhiteSpace(cartId)) throw new ArgumentNullException(nameof(cartId));

            _shoppingCartItemRepository.Add(new ShoppingCartItem()
            {
                ShopItemId = shopItemId,
                ShoppingCartId = cartId
            });
        }
    }
}