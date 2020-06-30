using System;
using System.Collections.Generic;
using Application.Interfaces.Persistence;
using Application.Orders.Commands.CreateOrder.Factory;
using Application.Orders.Commands.CreateOrder.Repository;
using Application.ShoppingCartItems.Commands.ClearShoppingCart;
using Common.Dates;
using Domain.Customers;
using Domain.OrderDetails;
using Domain.Orders;

namespace Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : ICreateOrderCommand
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IOrderFactory _orderFactory;
        private readonly IClearShoppingCartCommand _clearShoppingCartCommand;
        private readonly IOrderRepositoryFacade _orderRepositoryFacade;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommand(IDateTimeService dateTimeService,
            IOrderRepositoryFacade orderRepositoryFacade,
            IOrderFactory orderFactory,
            IClearShoppingCartCommand clearShoppingCartCommand,
            IUnitOfWork unitOfWork)
        {
            _dateTimeService = dateTimeService;
            _orderRepositoryFacade = orderRepositoryFacade;
            _orderFactory = orderFactory;
            _clearShoppingCartCommand = clearShoppingCartCommand;
            _unitOfWork = unitOfWork;
        }

        public void Execute(CreateOrderModel model)
        {
            var dateTime = _dateTimeService.GetDateTime();
            var customer = _orderRepositoryFacade.GetCustomerByEmail(model.CustomerEmail);
            var shopItems = _orderRepositoryFacade.GetCartItems(model.ShoppingCartId);

            var order = _orderFactory.Create(dateTime, customer, shopItems);

            //var order = new Order()
            //{
            //    OrderDetails = new List<OrderDetail>()
            //    {
            //        new OrderDetail(){ShopItemId = 1, Price =1},
            //        new OrderDetail(){ShopItemId = 2, Price = 2}
            //    },
            //    Customer = new Customer() { FirstName = "Gordon", LastName = "Freeman" },
            //    OrderPlaced = DateTime.UtcNow,
            //    OrderTotal = 1010
            //};

            _orderRepositoryFacade.AddOrder(order);

            _clearShoppingCartCommand.Execute(model.ShoppingCartId);

            _unitOfWork.Save();

            //Todo Notify inventory
        }
    }
}