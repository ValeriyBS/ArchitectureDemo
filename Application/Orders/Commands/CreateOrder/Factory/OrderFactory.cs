using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Customers;
using Domain.OrderDetails;
using Domain.Orders;
using Domain.ShoppingCartItems;

namespace Application.Orders.Commands.CreateOrder.Factory
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IMapper _mapper;

        public OrderFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Order Create(DateTime dateTime, Customer customer, IList<ShoppingCartItem> shopItems)
        {
            if (customer is null) throw new ArgumentNullException(nameof(customer));
            if (shopItems is null) throw new ArgumentNullException(nameof(shopItems));
            if (shopItems.Count == 0) throw new ArgumentException("Shop items list is empty");

            var order = new Order
            {
                Customer = customer,
                OrderPlaced = dateTime,
                OrderDetails = new List<OrderDetail>(),
                OrderTotal = shopItems.Sum(i => i.ShopItem.Price)
            };

            foreach (var item in shopItems)
            {
                var orderDetail = _mapper.Map<OrderDetail>(item);
                orderDetail.Order = order;
                order.OrderDetails.Add(orderDetail);
            }

            return order;
        }
    }
}