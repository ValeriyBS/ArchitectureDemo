using System.Collections.Generic;
using Domain.Orders;

namespace Application.Orders.Commands.CreateOrdersListViewModel.Factory
{
    public interface IOrdersListViewModelFactory
    {
        OrdersListViewModel Create(IList<Order> orders,int pageSize, int pageIndex);
    }
}