using System.Collections.Generic;
using Domain.Orders;

namespace Application.Orders.Queries.GetUserOrdersList
{
    public interface IGetUserOrdersListQuery
    {
        IList<Order> Execute(string userId);
    }
}