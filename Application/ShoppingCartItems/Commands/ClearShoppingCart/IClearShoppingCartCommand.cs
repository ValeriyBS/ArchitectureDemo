namespace Application.ShoppingCartItems.Commands.ClearShoppingCart
{
    public interface IClearShoppingCartCommand
    {
        void Execute(string cartId);
    }
}