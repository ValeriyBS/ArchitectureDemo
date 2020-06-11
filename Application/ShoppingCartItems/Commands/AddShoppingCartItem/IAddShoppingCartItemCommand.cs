namespace Application.ShoppingCartItems.Commands.AddShoppingCartItem
{
    public interface IAddShoppingCartItemCommand
    {
        void Execute(int shopItemId, string cartId);
    }
}