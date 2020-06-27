using Application.Interfaces.Persistence;
using Application.Orders.Commands.CreateOrder.Factory;
using Application.Orders.Commands.CreateOrder.Repository;
using Common.Dates;

namespace Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : ICreateOrderCommand
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IOrderFactory _orderFactory;
        private readonly IOrderRepositoryFacade _orderRepositoryFacade;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommand(IDateTimeService dateTimeService,
            IOrderRepositoryFacade orderRepositoryFacade,
            IOrderFactory orderFactory,
            IUnitOfWork unitOfWork)
        {
            _dateTimeService = dateTimeService;
            _orderRepositoryFacade = orderRepositoryFacade;
            _orderFactory = orderFactory;
            _unitOfWork = unitOfWork;
        }

        public void Execute(CreateOrderModel model)
        {
            var dateTime = _dateTimeService.GetDateTime();
            var customer = _orderRepositoryFacade.GetCustomerByEmail(model.CustomerEmail);
            var shopItems = _orderRepositoryFacade.GetCartItems(model.ShoppingCartId);

            var order = _orderFactory.Create(dateTime, customer, shopItems);

            _orderRepositoryFacade.AddOrder(order);

            _unitOfWork.Save();

            //Todo Notify inventory
        }
    }
}