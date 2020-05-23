using Application.ShoppingCarts.Factory;

namespace Presentation.ShoppingCarts.Services.Queries
{
    public class GetShoppingCart
    {
        private readonly IShoppingCartFactory _shoppingCartFactory;

        public GetShoppingCart(IShoppingCartFactory shoppingCartFactory)
        {
            _shoppingCartFactory = shoppingCartFactory;
        }

    }
}
