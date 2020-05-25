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

        public void Execute(ShoppingCartItem shoppingCartItem)
        {
            var nonNullShoppingCartItem = shoppingCartItem ?? throw new ArgumentNullException(nameof(shoppingCartItem));

            var existingShoppingCartItem = _shoppingCartItemRepository
            .GetAll()
            .Where(i => i.ShoppingCartId == nonNullShoppingCartItem.ShoppingCartId)
            .SingleOrDefault(i=>i.ShopItem.Id == nonNullShoppingCartItem.ShopItem.Id);


            if (existingShoppingCartItem is null)
                _shoppingCartItemRepository.Add(nonNullShoppingCartItem);
            else
                existingShoppingCartItem
                    .Amount++;


            _shoppingCartItemRepository.Save();
        }
    }
}