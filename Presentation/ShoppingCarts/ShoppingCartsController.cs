using Application.ShopItems.Queries.GetShopItemsList;
using Application.ShoppingCartItems.Commands;
using Application.ShoppingCartItems.Commands.AddShoppingCartItem;
using Application.ShoppingCartItems.Commands.RemoveShoppingCartItem;
using Application.ShoppingCartItems.Queries;
using Application.ShoppingCartItems.Queries.GetShoppingCartItemsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ShoppingCarts.Services.Queries;

namespace Presentation.ShoppingCarts
{
    public class ShoppingCartsController : Controller
    {
        private readonly IAddShoppingCartItemCommand _addShoppingCartItemCommand;
        private readonly IGetShopItemsListQuery _getShopItemsListQuery;
        private readonly CartIdProvider _cartIdProvider;
        private readonly IGetShoppingCartItemsListQuery _getShoppingCartItemsListQuery;
        private readonly IRemoveShoppingCartItemCommand _removeShoppingCartItemCommand;

        public ShoppingCartsController(CartIdProvider cartIdProvider,
            IGetShopItemsListQuery getShopItemsListQuery,
            IGetShoppingCartItemsListQuery getShoppingCartItemsListQuery,
            IAddShoppingCartItemCommand addShoppingCartItemCommand,
            IRemoveShoppingCartItemCommand removeShoppingCartItemCommand)
        {
            //_cartIdProvider = cartIdProvider;
            _getShopItemsListQuery = getShopItemsListQuery;
            _getShoppingCartItemsListQuery = getShoppingCartItemsListQuery;
            _addShoppingCartItemCommand = addShoppingCartItemCommand;
            _removeShoppingCartItemCommand = removeShoppingCartItemCommand;
            _cartIdProvider = cartIdProvider;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var shoppingCartItems = _getShoppingCartItemsListQuery.Execute(_cartIdProvider.CartId);

            var shoppingCartModel = new ShoppingCartModel(_cartIdProvider.CartId)
            {
                ShoppingCartItems = shoppingCartItems
            };

            return View(shoppingCartModel);
        }

        public IActionResult AddToCart(int shopItemId)
        {
            var shopItemModel = _getShopItemsListQuery.Execute(shopItemId);

            if (shopItemModel.Id == 0) return RedirectToAction("Index");

            _addShoppingCartItemCommand.Execute(shopItemId, _cartIdProvider.CartId);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int shopItemId)
        {
            var shopItemModel = _getShopItemsListQuery.Execute(shopItemId);

            if (shopItemModel.Id == 0) return RedirectToAction("Index");

            _removeShoppingCartItemCommand.Execute(shopItemId, _cartIdProvider.CartId);
            return RedirectToAction("Index");
        }
    }
}