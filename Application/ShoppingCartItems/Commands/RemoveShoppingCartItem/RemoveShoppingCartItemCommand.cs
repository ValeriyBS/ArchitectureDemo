using System;
using Application.Interfaces.Persistence;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Commands.RemoveShoppingCartItem
{
    public class RemoveShoppingCartItemCommand : IRemoveShoppingCartItemCommand
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public RemoveShoppingCartItemCommand(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }
        public void Execute(int shopItemId, string cartId)
        {
            if(cartId is null) throw new ArgumentNullException(nameof(cartId));

            _shoppingCartItemRepository.Remove(new ShoppingCartItem()
            {
                ShopItemId = shopItemId,
                ShoppingCartId = cartId
            });
        }
    }
}
