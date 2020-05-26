namespace Application.ShoppingCartItems.Commands
{
    public interface IRemoveShoppingCartItemCommand
    {
        void Execute(int shopItemId, string sessionId);
    }
}