using System;
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
                .ToList() ?? throw new KeyNotFoundException(cartId);
        }

        public Customer GetCustomer(string customerId)
        {
            return _customerRepository.GetAll()
                .SingleOrDefault(c => c.UserId == customerId) ?? throw new KeyNotFoundException(customerId);
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
        }
    }
}