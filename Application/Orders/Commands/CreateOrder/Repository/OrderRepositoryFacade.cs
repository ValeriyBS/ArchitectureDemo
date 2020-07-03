using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Customers;
using Domain.Orders;
using Domain.ShoppingCartItems;

namespace Application.Orders.Commands.CreateOrder.Repository
{
    public class OrderRepositoryFacade : IOrderRepositoryFacade
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public OrderRepositoryFacade(IOrderRepository orderRepository,
            IShoppingCartItemRepository shoppingCartItemRepository,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _customerRepository = customerRepository;
        }

        public IList<ShoppingCartItem> GetCartItems(string cartId)
        {
            return _shoppingCartItemRepository
                .GetAll()
                .Where(i => i.ShoppingCartId == cartId)
                .ToList();
        }

        public Customer GetCustomer(string customerId)
        {
            return _customerRepository.GetAll()
                .SingleOrDefault(c => c.Email == customerId);
            //Todo change email to Id in the domain model and database
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
        }
    }
}