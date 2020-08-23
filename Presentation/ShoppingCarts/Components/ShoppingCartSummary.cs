using Application.ShoppingCartItems.Queries.GetShoppingCartItemsList;
using Microsoft.AspNetCore.Mvc;
using Presentation.ShoppingCarts.Services.Queries;

namespace Presentation.ShoppingCarts.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly CartIdProvider _cartIdProvider;
        private readonly IGetShoppingCartItemsListQuery _getShoppingCartItemsListQuery;

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