using System;
using Application.Interfaces.Persistence;

namespace Application.ShoppingCartItems.Commands.ClearShoppingCart
{
    public class ClearShoppingCartCommand : IClearShoppingCartCommand
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public ClearShoppingCartCommand(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public void Execute(string cartId)
        {
            if (cartId is null) throw new ArgumentNullException(nameof(cartId));

            _shoppingCartItemRepository.Clear(cartId);
        }
    }
}