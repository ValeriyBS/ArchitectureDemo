using System.Collections.Generic;
using Domain.Customers;
using Domain.Orders;
using Domain.ShoppingCartItems;

namespace Application.Orders.Commands.CreateOrder.Repository
{
    public interface IOrderRepositoryFacade
    {
        IList<ShoppingCartItem> GetCartItems(string cartId);
        Customer GetCustomer(string customerId);
        void AddOrder(Order order);
    }
}