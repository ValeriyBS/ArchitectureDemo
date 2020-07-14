using System.Linq;
using System.Threading.Tasks;
using Application.Orders.Commands.CreateOrder;
using Application.Orders.Commands.CreateOrdersListViewModel.Factory;
using Application.Orders.ExtensionMethods;
using Application.Orders.Queries.GetUserOrdersList;
using Application.ShoppingCartItems.Queries.GetShoppingCartItemsList;
using Common.Dates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Orders.Models;
using Presentation.Orders.Services.Commands.SaveApplicationUser;
using Presentation.Orders.Services.Queries.GetApplicationUser;
using Presentation.ShoppingCarts.Services.Queries;

namespace Presentation.Orders
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly CartIdProvider _cartIdProvider;
        private readonly ICreateOrderCommand _createOrderCommand;
        private readonly IDateTimeService _dateTimeService;
        private readonly IOrdersListViewModelFactory _ordersListViewModelFactory;
        private readonly IEmailSender _emailSender;
        private readonly IGetApplicationUserDetails _getApplicationUserDetails;
        private readonly IGetApplicationUserId _getApplicationUserId;
        private readonly IGetShoppingCartItemsListQuery _getShoppingCartItemsListQuery;
        private readonly IGetUserOrdersListQuery _getUserOrdersListQuery;
        private readonly ISaveApplicationUserDetails _saveApplicationUserDetails;

        public OrdersController(CartIdProvider cartIdProvider,
            IGetShoppingCartItemsListQuery getShoppingCartItemsListQuery,
            ICreateOrderCommand createOrderCommand,
            IGetApplicationUserDetails getApplicationUserDetails,
            IGetApplicationUserId getApplicationUserId,
            ISaveApplicationUserDetails saveApplicationUserDetails,
            IGetUserOrdersListQuery getUserOrdersListQuery,
            IDateTimeService dateTimeService,
            IOrdersListViewModelFactory ordersListViewModelFactory,
            IEmailSender emailSender)
        {
            _cartIdProvider = cartIdProvider;
            _getShoppingCartItemsListQuery = getShoppingCartItemsListQuery;
            _createOrderCommand = createOrderCommand;
            _getApplicationUserDetails = getApplicationUserDetails;
            _getApplicationUserId = getApplicationUserId;
            _saveApplicationUserDetails = saveApplicationUserDetails;
            _getUserOrdersListQuery = getUserOrdersListQuery;
            _dateTimeService = dateTimeService;
            _ordersListViewModelFactory = ordersListViewModelFactory;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Checkout()
        {
            var viewModel = await _getApplicationUserDetails.Execute(HttpContext.User);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Checkout(CreateOrderViewModel viewModel)
        {
            if (!ModelState.IsValid) return View();

            var shoppingCartItems = _getShoppingCartItemsListQuery.Execute(_cartIdProvider.CartId);

            if (!shoppingCartItems.Any()) ModelState.AddModelError("", "You cart is empty.Add some goods first");

            var userId = _getApplicationUserId.Execute(HttpContext.User);

            _saveApplicationUserDetails.Execute(userId, viewModel);

            var orderModel = new CreateOrderModel(userId, _cartIdProvider.CartId);

            _createOrderCommand.Execute(orderModel);

            return RedirectToAction("CheckoutComplete", new {userId, userEmail = viewModel.Email});
        }


        public IActionResult CheckoutComplete(string userId, string userEmail)
        {
            var order = _getUserOrdersListQuery.Execute(userId).Last();

            order.OrderPlaced = _dateTimeService.UtcToLocal(order.OrderPlaced);

            var htmlMessage = order.ToHtmlMessage();

            _emailSender.SendEmailAsync(userEmail, $"Order ref:{order.Id} confirmation", htmlMessage );

            return View(order);
        }


        public IActionResult List(int pageSize, int pageIndex)
        {
            var userId = _getApplicationUserId.Execute(HttpContext.User);

            var orders = _getUserOrdersListQuery.Execute(userId);

            var ordersListViewModel = _ordersListViewModelFactory.Create(orders, pageSize, pageIndex);

            return View(ordersListViewModel);
        }
    }
}