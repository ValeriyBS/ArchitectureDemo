using System.Linq;
using Application.Orders.Commands.CreateOrder;
using Application.ShoppingCartItems.Queries.GetShoppingCartItemsList;
using Microsoft.AspNetCore.Mvc;
using Presentation.Orders.Models;
using Presentation.ShoppingCarts.Services.Queries;

namespace Presentation.Orders
{
    public class OrdersController : Controller
    {
        private readonly CartIdProvider _cartIdProvider;
        private readonly IGetShoppingCartItemsListQuery _getShoppingCartItemsListQuery;
        private readonly ICreateOrderCommand _createOrderCommand;

        public OrdersController(CartIdProvider cartIdProvider,
            IGetShoppingCartItemsListQuery getShoppingCartItemsListQuery,
            ICreateOrderCommand createOrderCommand)
        {
            _cartIdProvider = cartIdProvider;
            _getShoppingCartItemsListQuery = getShoppingCartItemsListQuery;
            _createOrderCommand = createOrderCommand;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(CreateOrderViewModel viewModel)
        {
            if (!ModelState.IsValid) return View();

            var shoppingCartItems = _getShoppingCartItemsListQuery.Execute(_cartIdProvider.CartId);

            if (!shoppingCartItems.Any()) ModelState.AddModelError("", "You cart is empty.Add some goods first");

            var orderModel = new CreateOrderModel(1, _cartIdProvider.CartId);

            _createOrderCommand.Execute(orderModel);

            return RedirectToAction("CheckoutComplete");
        }


        public IActionResult CheckoutComplete()
        {
            return View();
        }
    }
}