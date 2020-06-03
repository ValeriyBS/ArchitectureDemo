using Application.ShoppingCartItems.Queries;
using Microsoft.AspNetCore.Mvc;
using Presentation.ShoppingCarts.Services.Queries;

namespace Presentation.ShoppingCarts.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IGetShoppingCartItemsListQuery _getShoppingCartItemsListQuery;
        private readonly CartIdProvider _cartIdProvider;

        public ShoppingCartSummary(CartIdProvider cartIdProvider,
            IGetShoppingCartItemsListQuery getShoppingCartItemsListQuery)
        {
            _getShoppingCartItemsListQuery = getShoppingCartItemsListQuery;
            _cartIdProvider = cartIdProvider;
        }

        public IViewComponentResult Invoke()
        {
            var cartId = _cartIdProvider.CartId;
            var shoppingCartModel = new ShoppingCartModel(cartId)
            {
                ShoppingCartItems = _getShoppingCartItemsListQuery.Execute(cartId)
            };
            return View(shoppingCartModel);
        }
    }
}