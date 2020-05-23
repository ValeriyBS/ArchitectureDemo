using Application.ShoppingCarts.Queries;

namespace Application.ShoppingCarts.Factory
{
    public interface IShoppingCartFactory
    {
        ShoppingCart Create(string cartId);
    }
}