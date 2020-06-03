using Application.ShopItems.Queries.GetShopItemsList;
using Application.ShoppingCartItems.Commands;
using Application.ShoppingCartItems.Queries;
using Microsoft.AspNetCore.Mvc;
using Presentation.ShoppingCarts.Services.Queries;

namespace Presentation.ShoppingCarts
{
    public class ShoppingCartsController : Controller
    {
        private readonly IAddShoppingCartItemCommand _addShoppingCartItemCommand;
        private readonly IGetShopItemsListQuery _getShopItemsListQuery;
        private readonly GetShoppingCart _getShoppingCart;
        private readonly IGetShoppingCartItemsListQuery _getShoppingCartItemsListQuery;
        private readonly IRemoveShoppingCartItemCommand _removeShoppingCartItemCommand;


        private ShoppingCartModel _shoppingCartModel;

        public ShoppingCartsController(GetShoppingCart getShoppingCart,
            IGetShopItemsListQuery getShopItemsListQuery,
            IGetShoppingCartItemsListQuery getShoppingCartItemsListQuery,
            IAddShoppingCartItemCommand addShoppingCartItemCommand,
            IRemoveShoppingCartItemCommand removeShoppingCartItemCommand)
        {
            _getShoppingCart = getShoppingCart;
            _getShopItemsListQuery = getShopItemsListQuery;
            _getShoppingCartItemsListQuery = getShoppingCartItemsListQuery;
            _addShoppingCartItemCommand = addShoppingCartItemCommand;
            _removeShoppingCartItemCommand = removeShoppingCartItemCommand;
            _shoppingCartModel = new ShoppingCartModel(_getShoppingCart.SessionId);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var shoppingCartItems = _getShoppingCartItemsListQuery.Execute(_getShoppingCart.SessionId);

            _shoppingCartModel = new ShoppingCartModel(_getShoppingCart.SessionId)
            {
                ShoppingCartItems = shoppingCartItems
            };

            return View(_shoppingCartModel);
        }

        public IActionResult AddToCart(int shopItemId)
        {
            var shopItemModel = _getShopItemsListQuery.Execute(shopItemId);

            if (shopItemModel.Id == 0) return RedirectToAction("Index");

            _addShoppingCartItemCommand.Execute(shopItemId, _getShoppingCart.SessionId);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int shopItemId)
        {
            var shopItemModel = _getShopItemsListQuery.Execute(shopItemId);

            if (shopItemModel.Id == 0) return RedirectToAction("Index");

            _removeShoppingCartItemCommand.Execute(shopItemId, _getShoppingCart.SessionId);
            return RedirectToAction("Index");
        }
    }
}