namespace Application.ShoppingCartItems.Commands.RemoveShoppingCartItem
{
    public interface IRemoveShoppingCartItemCommand
    {
        void Execute(int shopItemId, string sessionId);
    }
}