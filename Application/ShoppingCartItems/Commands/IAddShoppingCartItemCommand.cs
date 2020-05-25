using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Commands
{
    public interface IAddShoppingCartItemCommand
    {
        void Execute(ShoppingCartItem shoppingCartItem);
    }
}