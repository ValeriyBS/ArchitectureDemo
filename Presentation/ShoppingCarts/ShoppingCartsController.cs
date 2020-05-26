using System.Linq;
using Application.Interfaces.Persistence;
using Application.ShopItems.Queries.GetShopItemsList;
using Application.ShoppingCartItems.Commands;
using Application.ShoppingCartItems.Queries;
using Application.ShoppingCarts.Factory;
using Application.ShoppingCarts.Queries;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Microsoft.AspNetCore.Mvc;
using Presentation.ShoppingCarts.Services.Queries;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.ShoppingCarts
{
    public class ShoppingCartsController : Controller
    {
        private readonly GetShoppingCart _getShoppingCart;
        private readonly IGetShopItemsListQuery _getShopItemsList;
        private readonly IGetShoppingCartItemsListQuery _getShoppingCartItemsListQuery;
        private readonly IAddShoppingCartItemCommand _addShoppingCartItemCommand;
        private readonly IRemoveShoppingCartItemCommand _removeShoppingCartItemCommand;


        private ShoppingCartModel _shoppingCartModel;
        //private readonly IShoppingCart _shoppingCart;

        //public ShoppingCartController(IShoppingCart shoppingCart)
        public ShoppingCartsController(GetShoppingCart getShoppingCart,
            IGetShopItemsListQuery getShopItemsList,
            IGetShoppingCartItemsListQuery getShoppingCartItemsListQuery,
            IAddShoppingCartItemCommand addShoppingCartItemCommand,
            IRemoveShoppingCartItemCommand removeShoppingCartItemCommand)
        {
            _getShoppingCart = getShoppingCart;
            _getShopItemsList = getShopItemsList;
            _getShoppingCartItemsListQuery = getShoppingCartItemsListQuery;
            _addShoppingCartItemCommand = addShoppingCartItemCommand;
            _removeShoppingCartItemCommand = removeShoppingCartItemCommand;
            _shoppingCartModel = new ShoppingCartModel(_getShoppingCart.SessionId);
           // _shoppingCart = shoppingCartFactory.Create(_getShoppingCart.SessionId);

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var shoppingCartItems=_getShoppingCartItemsListQuery.Execute(_getShoppingCart.SessionId);

            _shoppingCartModel = new ShoppingCartModel(_getShoppingCart.SessionId)
            {
                ShoppingCartItems = shoppingCartItems
            };

            return View(_shoppingCartModel);
        }

        public IActionResult AddToCart(int shopItemId)
        {
            var shopItemModel = _getShopItemsList.Execute(shopItemId).FirstOrDefault();

            if (shopItemModel is null) return RedirectToAction("Index");

            _addShoppingCartItemCommand.Execute(shopItemId,_getShoppingCart.SessionId);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int shopItemId)
        {
            var shopItemModel = _getShopItemsList.Execute(shopItemId).FirstOrDefault();

            if (shopItemModel is null) return RedirectToAction("Index");

            _removeShoppingCartItemCommand.Execute(shopItemId, _getShoppingCart.SessionId);
            return RedirectToAction("Index");
        }

    }
}