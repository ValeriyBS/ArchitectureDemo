using Application.ShoppingCartItems.Queries;
using Microsoft.AspNetCore.Mvc;
using Presentation.ShoppingCarts.Services.Queries;

namespace Presentation.ShoppingCarts.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IGetShoppingCartItemsListQuery _getShoppingCartItemsListQuery;
        private readonly GetShoppingCart _getShoppingCart;

        public ShoppingCartSummary(IGetShoppingCartItemsListQuery getShoppingCartItemsListQuery,
            GetShoppingCart getShoppingCart)
        {
            _getShoppingCartItemsListQuery = getShoppingCartItemsListQuery;
            _getShoppingCart = getShoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var shoppingCartModel = new ShoppingCartModel(_getShoppingCart.SessionId)
            {
                ShoppingCartItems = _getShoppingCartItemsListQuery.Execute(_getShoppingCart.SessionId)
            };
            return View(shoppingCartModel);
        }
    }
}