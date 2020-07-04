using System;
using System.Collections.Generic;
using Application.Interfaces.Persistence;
using Domain.Orders;

namespace Application.Orders.Queries.GetUserOrdersList
{
    public class GetUserOrdersListQuery
    {
        private readonly IOrderRepository _orderRepository;

        public GetUserOrdersListQuery(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IList<Order> Execute(string userId)
        {
            if (userId is null) throw new ArgumentNullException(nameof(userId));

            return _orderRepository.GetByUserId(userId);
        }
    }
}