using System;
using System.Collections.Generic;
using Domain.Customers;
using Domain.Orders;
using Domain.ShoppingCartItems;

namespace Application.Orders.Commands.CreateOrder.Factory
{
    public interface IOrderFactory
    {
        Order Create(DateTime dateTime, Customer customer, IList<ShoppingCartItem> shopItems);
    }
}