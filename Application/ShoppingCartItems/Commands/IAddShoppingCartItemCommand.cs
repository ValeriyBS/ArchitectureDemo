using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Commands
{
    public interface IAddShoppingCartItemCommand
    {
        void Execute(int shopItemId, string cartId);
    }
}