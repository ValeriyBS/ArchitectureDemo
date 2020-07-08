using Application.Interfaces.Infrastructure;
using Application.Interfaces.Persistence;
using Application.Orders.Commands.CreateOrder.Factory;
using Application.Orders.Commands.CreateOrder.Repository;
using Application.ShoppingCartItems.Commands.ClearShoppingCart;
using Common.Dates;
using Domain.Customers;

namespace Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : ICreateOrderCommand
    {
        private readonly IClearShoppingCartCommand _clearShoppingCartCommand;
        private readonly IDateTimeService _dateTimeService;
        private readonly IOrderFactory _orderFactory;
        private readonly IOrderRepositoryFacade _orderRepositoryFacade;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInventoryService _inventoryService;

        public CreateOrderCommand(IDateTimeService dateTimeService,
            IOrderRepositoryFacade orderRepositoryFacade,
            IOrderFactory orderFactory,
            IClearShoppingCartCommand clearShoppingCartCommand,
            IUnitOfWork unitOfWork,
            IInventoryService inventoryService)
        {
            _dateTimeService = dateTimeService;
            _orderRepositoryFacade = orderRepositoryFacade;
            _orderFactory = orderFactory;
            _clearShoppingCartCommand = clearShoppingCartCommand;
            _unitOfWork = unitOfWork;
            _inventoryService = inventoryService;
        }

        public void Execute(CreateOrderModel model)
        {
            var dateTime = _dateTimeService.GetDateTimeUtc();
            var customer = _orderRepositoryFacade.GetCustomer(model.CustomerId)
                           ?? new Customer {UserId = model.CustomerId};
            var shopItems = _orderRepositoryFacade.GetCartItems(model.ShoppingCartId);

            var order = _orderFactory.Create(dateTime, customer, shopItems);

            _orderRepositoryFacade.AddOrder(order);

            _clearShoppingCartCommand.Execute(model.ShoppingCartId);

            _unitOfWork.Save();

            foreach (var shopItem in shopItems)
            {
                _inventoryService.NotifyItemSold(shopItem.Id,shopItem.Amount);
            }
        }
    }
}