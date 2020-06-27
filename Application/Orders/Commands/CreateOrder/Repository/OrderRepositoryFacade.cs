using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces.Persistence;
using Domain.Customers;
using Domain.Orders;
using Domain.ShoppingCartItems;

namespace Application.Orders.Commands.CreateOrder.Repository
{
    public class OrderRepositoryFacade : IOrderRepositoryFacade
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly ICustomerRepository _customerRepository;

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

        public Customer GetCustomerByEmail(string customerEmail)
        {
            return _customerRepository
                .GetAll()
                .SingleOrDefault(c => c.Email == customerEmail);
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
        }
    }
}
